using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int freeParkingValue;
    public GameObject mainMenu;
    public GameUIManager UIManager;
    public PropertySpawner propSpawner;

    public GameObject gameMenu;
    public Transform playerIndicator;
    public Text timerText;
    public Text gamemodeText;
    public Text playerListText;
    public SystemMsgs messager;

    public GameObject menuCam;
    public GameObject mainCam;

    public Dropdown gamemodeChooser;
    public Slider playerSlider;
    public InputField timeInput;

    public GameObject pieceErrorText;
    public GameObject nameErrorText;

    public Button startBtn;

    public Piece[] pieces;
    public GameObject[] playerInfoEntry;
    public BoardTile[] tiles;
    public GameObject tileParent;
    public BoardTile selectedProperty;
    public Text apl;

    public CardStack potLuckStack;
    public CardStack opportunityStack;
    public Card recentCard; 
    public Player[] players;
    public Player bankerAI;
    public System.Random rand = new System.Random();
    private int activePlayerID;
    public Player activePlayer;
    private float timeLeft;
    private int doubleTracker = 0;
    private gameType gamemode;

    /*
     * Function: Start (MonoBehavior function - called when script instantiated)
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: runs like a class constructor
     */
    private void Start()
    {
        setPieceOptions(null);
    }

    /*
     * Function: Update (MonoBehavior function - called every frame)
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: called once for every frame
     */
    private void Update()
    {
        if (activePlayer != null)
        {
            updatePlayers();
            apl.text = "Currently on: " + getTileObject(activePlayer.gamePiece.currentTile).name;
        }
        if (gamemode == gameType.TIMED)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = ((int)(timeLeft / 60f)).ToString() + " min(s)";
        }
    }

    /*
     * Function: setPieceOptions
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: sets the piece options dropdowns to the names of the pieces
     */
    private void setPieceOptions(GameObject exclude)
    {
        foreach (GameObject infoEntry in playerInfoEntry)
        {
            List<string> options = new List<string>();
            foreach (Piece piece in pieces)
            {
                options.Add(piece.pieceName);
            }

            Dropdown dd = infoEntry.transform.GetChild(0).GetComponent<Dropdown>();
            dd.AddOptions(options);
        }
    }

    /*
     * Function: countActiveDropdowns
     * Parameters: N/A 
     * Returns: integer value 
     * Purpose: returns the amount active dropdowns (players)
     */
    private int countActiveDropdowns()
    {
        int count = 0;
        foreach (GameObject dd in playerInfoEntry)
        {
            if (dd.activeSelf)
            {
                count++;
            }
        }
        return count;
    }

    /*
     * Function: onPlayerInfoChange
     * Parameters: N/A
     * Returns: N/A
     * Purpose: called when input boxes or dropdown is changed when choosing player names and pieces
     */
    public void onPlayerInfoChange()
    {
        if (countActiveDropdowns() > 1)
        {
            bool pieceUnique = true;
            bool nameUnique = true;
            foreach (GameObject info1 in playerInfoEntry)
            {
                foreach (GameObject info2 in playerInfoEntry)
                {
                    if (info1.activeInHierarchy && info2.activeInHierarchy && info1 != info2)
                    {
                        Dropdown dropdown1 = info1.transform.GetChild(0).GetComponent<Dropdown>();
                        Dropdown dropdown2 = info2.transform.GetChild(0).GetComponent<Dropdown>();

                        string text1 = info1.transform.GetChild(1).GetComponent<InputField>().text;
                        string text2 = info2.transform.GetChild(1).GetComponent<InputField>().text;

                        if (dropdown1.value == dropdown2.value)
                        {
                            pieceUnique = false;
                        }

                        if (text1 == text2)
                        {
                            nameUnique = false;
                        }
                    }
                }
            }

            if (!pieceUnique)
            {
                pieceErrorText.SetActive(true);
                startBtn.interactable = false;
            }
            else
            {
                pieceErrorText.SetActive(false);
            }

            if (!nameUnique)
            {
                nameErrorText.SetActive(true);
                startBtn.interactable = false;
            }
            else
            {
                nameErrorText.SetActive(false);
            }

            if (pieceUnique && nameUnique)
            {
                startBtn.interactable = true;
            }
        }
        else
        {
            pieceErrorText.SetActive(false);
            nameErrorText.SetActive(false);
            startBtn.interactable = true;
        }
    }

    /*
     * Function: rollDice
     * Parameters: bool track - whether or not this dice roll should be tracked 
     * Returns: N/A
     * Purpose: used to generate random dice roll and track number of doubles rolled
     */
    public void rollDice(bool track)
    {   
        Dice dice = new Dice();
        if (track)
        {
            doubleTracker = dice.isDouble ? doubleTracker + 1 : 0;
        }

        if (!dice.isDouble || doubleTracker >= 3)
        {
            UIManager.ToggleRTDButton(false);
        }

        messager.NewMessage(activePlayer.playerName + " rolled: " + dice.value + (dice.isDouble ? " with a double!" : "!"));

        if (doubleTracker >= 3)
        {
            activePlayer.gamePiece.sendToJail();
        }
        else
        {
            activePlayer.gamePiece.movePiece(dice.value);
        }
        
        UIManager.UpdatePropertyList();
        turn();
    }

    /*
     * Function: turn
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: runs the main part of the game round by round
     */
    void turn()
    {
        int playerLocation = activePlayer.gamePiece.getCurrentTile();
        BoardTile playerLocationTile = getBoardTileFromIndex(playerLocation);

        switch (playerLocationTile.type)
        {
            case tileType.GO:
                messager.NewMessage(activePlayer.playerName + "Landed On GO, Recieve ??200" );
                activePlayer.addCash(200);

                break;
            
            case tileType.PROPERTY:
                // Handled by player selecting buttons
                break;
            
            case tileType.OPKNOCKS:
                //card stuff
                recentCard = opportunityStack.popNextCard();
                messager.NewMessage(recentCard.title);
                // active player and banker
                recentCard.completeAction(activePlayer, bankerAI);
                break;
            
            case tileType.POTLUCK:
                //card stuff
                recentCard = potLuckStack.popNextCard();
                messager.NewMessage(recentCard.title);
                // active player and banker
                recentCard.completeAction(activePlayer, bankerAI);
                break;
            
            case tileType.FREEPARK:
                activePlayer.addCash(freeParkingValue);
                messager.NewMessage(activePlayer.playerName + "collected " + freeParkingValue + "from freeparking!" );
                freeParkingValue = 0;
                break;
            
            case tileType.GOTOJAIL:
                messager.NewMessage(activePlayer.playerName + "Sent To Jail" );
                activePlayer.gamePiece.currentTile = (41);
                activePlayer.gamePiece.moveHelper();
                break;
            
            case tileType.JAIL:
                if (playerLocation == 10)
                {
                    break;
                }
                else
                {
                    //jail stuff
                    messager.NewMessage(activePlayer.playerName + "is in jail!" );
                    break;
                }
            case tileType.SUPERTAX:
                messager.NewMessage(activePlayer.playerName + "Landed On Supertax, pay ??100" );
                activePlayer.addCash(-100);
                break;
            case tileType.INCOMETAX:
                messager.NewMessage(activePlayer.playerName + "Landed On Incometax, pay ??200" );
                activePlayer.addCash(-200);
                break;
                
        }

        if (activePlayer.getCash() < 1)
        {
            activePlayer.bankrupt = true;
        }
    }

    public void addToFreeParking(int amount)
    {
        freeParkingValue += amount; 
    } 

    /*
     * Function: getTileObject
     * Parameters: int index, the location of the tile on the board
     * Returns: GameObject instance of the board tile
     * Purpose: For getting the location of the board tile to move a game piece to it. 
     */
    public GameObject getTileObject(int index)
    {
        return tileParent.transform.GetChild(index).gameObject;
    }

    /*
     * Function: getBoardTileFromIndex
     * Parameters: int index, the location of the tile on the board
     * Returns: BoardTile which is the boardtile in that index
     * Purpose: For getting the location of the board tile from an index.
     */
    public BoardTile getBoardTileFromIndex(int index)
    {
        GameObject bt = tileParent.transform.GetChild(index).gameObject;
        return bt.GetComponent<BoardTile>();
    }


    /*
     * Function: onDropdownChange
     * Parameters: N/A 
     * Returns: N/A
     * Purpose: toggled the timer input for the custom timed gamemode
     */
    public void onGamemodeDropdownChange()
    {
        if (gamemodeChooser.value == 1)
        {
            timeInput.gameObject.SetActive(true);
        }
        else
        {
            timeInput.gameObject.SetActive(false);
        }
    }

    /*
     * Function: onSliderChange
     * Parameters: N/A 
     * Returns: N/A
     * Purpose: handles the player slider change
     */
    public void onSliderChange()
    {
        for (int i = 1; i < playerInfoEntry.Length; i++)
        {
            if (i < playerSlider.value)
            {
                playerInfoEntry[i].SetActive(true);
            }
            else
            {
                playerInfoEntry[i].SetActive(false);
            }
        }
        onPlayerInfoChange();
    }

    /*
     * Function: startGame
     * Parameters: N/A 
     * Returns: N/A
     * Purpose: called at the very start of the game, initiates everything and starts the round looper
     */
    public void startGame()
    {
        mainMenu.SetActive(false);
        mainCam.SetActive(true);
        menuCam.SetActive(false);

        gamemode = (gameType)gamemodeChooser.value;

        if (gamemodeChooser.value == 1)
        {
            gamemode = gameType.TIMED;
            if (!float.TryParse(timeInput.text, out timeLeft) || timeLeft < 30f)
            {
                timeLeft = 30f;
            }

            timeLeft *= 60;
        }

        playerSetup();
        gameUISetup();
        gameMenu.SetActive(true);
        // Set up board and properties
        // Set up card decks
        opportunityStack.shuffle();
        potLuckStack.shuffle();
        // End screen saying "eyyo g, you're amazing"
    }

    /*
     * Function: playersLeft
     * Parameters: N/A 
     * Returns: integer value representing the number of players left
     * Purpose: returns number of players left
     */
    public int playersLeft()
    {
        int check = 0;
        foreach (Player p in players)
        {
            if (!p.getBankrupt())
            {
                check++;
            }
            
        }
        return check;
    }

    /*
     * Function: playerSetup
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: sets up all the players for the game
     */
    void playerSetup()
    {
        players = new Player[countActiveDropdowns() + 1];

        for (int i = 0; i < players.Length; i++)
        {
            if (i < players.Length - 1)
            {
                players[i] = new Player();
                players[i].playerName = playerInfoEntry[i].transform.GetChild(1).GetComponent<InputField>().text;
                players[i].ai = false;

                Piece assignedPiece = pieces[playerInfoEntry[i].transform.GetChild(0).GetComponent<Dropdown>().value];
                assignedPiece.chosen = true;
                players[i].gamePiece = assignedPiece;

                players[i].cash = 1500;
            }
            else
            {
                players[players.Length - 1] = new Player();
                players[players.Length - 1].playerName = "[AI]Banker";
                bankerAI = players[players.Length - 1]; 

                Piece assignedPiece = findSparePiece();
                assignedPiece.chosen = true;
                players[i].gamePiece = assignedPiece;

                players[players.Length - 1].cash = 1500;
            }
        }
        activePlayerID = 0;
        activePlayer = players[activePlayerID];

        foreach (Piece pce in pieces)
        {
            if (!pce.chosen)
            {
                pce.gameObject.SetActive(false);
            }
        }
        
        UIManager.UpdatePropertyList();

        prettyDebugPlayers();
    }

    /*
     * Function: prettyDebugPlayers
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: prints to the console player information
     */
    private void prettyDebugPlayers()
    {
        foreach (Player player in players)
        {
            Debug.Log(player.playerName + " - " + player.gamePiece.pieceName + " - " + player.cash + "\n");
        }
    }

    /*
     * Function: findSparePiece
     * Parameters: N/A 
     * Returns: Piece instance
     * Purpose: returns a piece that hasn't been chosen yet
     */
    private Piece findSparePiece()
    {
        foreach (Piece piece in pieces)
        {
            if (!piece.chosen)
            {
                return piece;
            }
        }
        return null;
    }

    /*
     * Function: movePiece
     * Parameters: int amount - amount of spaces to move
     * Returns: N/A 
     * Purpose: moves the player 'amount' of spaces around the board
     */
    void movePiece(int amount)
    {
        activePlayer.gamePiece.movePiece(amount);
    }


    /*
     * Function: purchase
     * Parameters: N/A 
     * Returns: true if the player successfully purchases the property, false if unsuccessful.
     * Purpose: purchases the property that the current player lands on
     */
    public bool purchase()
    {   
        BoardTile bt = selectedProperty;

        if (activePlayer.gamePiece.getTotalTiles() < 40)
        {
            messager.NewMessage("Cannot purchase until completed A lap of the board");
            return false;
        }
        if (bt.type != tileType.PROPERTY)
        {
            messager.NewMessage("Cannot purchase A non-property tile");
            return false;
        }
        if (activePlayer.getCash() < bt.getCost())
        {
            messager.NewMessage(activePlayer.playerName + " cannot afford " + bt.tileName);
            return false;
        }
        if (bt.getOwner() != null && bt.getOwner() != activePlayer)
        {
            messager.NewMessage("Property is already owned");
            return false;
        }
        else
        {
            messager.NewMessage(activePlayer.playerName + " purchased " + bt.tileName);
            activePlayer.addToProperties(bt);
            return true;
        }
    }
        
    

    /*
     * Function: upgrade
     * Parameters: BoardTile prop - The desired property to be upgraded by the player 
     * Returns: N/A 
     * Purpose: upgrades property to houses then hotels
     */
    public bool upgrade()
    {
        BoardTile bt = selectedProperty;

        if (!(activePlayer.ownedProperties.Contains(bt)))
        {
            purchase();
            return false;
        }
        int count = 0;
        foreach (BoardTile property in activePlayer.ownedProperties)
        {
            //checking to see if player has all 3 property of the same colour before being allowed to upgrade
            if (property.getPC() == bt.getPC())
            {
                count++;
            }
            if (count == 3)
            {
                break;
            }
            else
            {
                messager.NewMessage(activePlayer.playerName + "Doesn't Own All Properies Of That Colour.");
                return false;
            }
        }
        if (bt.getNumOfHouse() == 5){
            messager.NewMessage("Cannot Upgrade This Property Anymore.");
            return false; 
        }
        bt.increaseNumOfHouse();

        for (int i = 0; i < tileParent.transform.childCount; i++)
        {
            if (selectedProperty == tileParent.transform.GetChild(i).gameObject.GetComponent<BoardTile>())
            {
                propSpawner.UpdateProperty(i, selectedProperty.numOfHouse);
            }
        }

        messager.NewMessage(activePlayer.playerName + " Upgraded Their Property.");
        return true; 
    }

    /*
    * Function: auction
    * Parameters: N/A 
    * Returns: Player value - who won the bid 
    * Purpose: 
    */
    public Player auction()
    {
        BoardTile bt = tiles[0]; // make current tile?!
        // Run when player does not purchase, gives property to highest bidder
        // Remains unsold if no bids

        int auctionCost = 0;
        int i = (Array.IndexOf(players, activePlayer) +1);
        Player highestBidder;
        bool end = false;

        do
        {
            // TODO: if player choose skip -- next player
            // TODO: if all players choose skip -- property sold to highest bidder. 
        }
        while (!end);

        
        return null;
    }

    /*
    * Function: mortgage
    * Parameters: BoardTile bt - the property in which is being mortaged.
    * Returns: a bool value, if the player succesfully mortgaged the property. 
    * Purpose: calls the addToMorgagedProperties function for the active player. 
    */
    public bool mortgage()
    {
        BoardTile bt = selectedProperty;

        
        if (activePlayer.addToMortgagedProperties(bt))
        {
            messager.NewMessage(activePlayer.playerName + " Mortgaged " + bt.tileName);
            return true;
        }
        else 
        {
            if (!activePlayer.ownedProperties.Contains(bt))
            {
                messager.NewMessage("Cannot Mortgage A Property That The Player Doesn't Own.");
            }
            else 
            {
                messager.NewMessage("Property Is Already Mortgaged.");
            }
            return false;
        }
    }


    /*
    * Function: unMortgage
    * Parameters: BoardTile bt - the property in which is being unmortaged.
    * Returns: a bool value, if the player succesfully unmortgaged the property. 
    * Purpose: calls the removeMortgage function for the active player. 
    */
    public bool unMortgage()
    {
        BoardTile bt = selectedProperty;
        if (activePlayer.removeMortgage(bt))
        {
            messager.NewMessage(activePlayer.playerName + " Unmortgaged " + bt.tileName);
            return true;
        }
        else 
        {
            if (activePlayer.getCash() < bt.getCost() / 2)
            {
                messager.NewMessage(activePlayer.playerName + " Cannot Afford To Unmortgage.");
                return false;
            }
            else
            {
                messager.NewMessage("Property Is Not Mortgaged");
                return false;
            }
        }
    }

    /*
    * Function: sell
    * Parameters: BoardTile bt - the property in which is being sold.
    * Returns: a bool value, if the player succesfully sells the property. 
    * Purpose: calls the sellProperty for the active player. 
    */
    public bool sell()
    {
        BoardTile bt = selectedProperty;
        if (activePlayer.sellProperty(bt))
        {
            messager.NewMessage(activePlayer.playerName +" Sold " + bt.tileName);
            return true;
        }
        else
        {
            messager.NewMessage(activePlayer.playerName + " Cannot Sell " + bt.tileName);
            return false;
        }
    }
    
    /*
    * Function: rent
    * Parameters: BoardTile bt - the property in which is being sold.
    * Returns: a bool value, if the player succesfully sells the property. 
    * Purpose: calls the sellProperty for the active player. 
    */
    public bool rent()
    {
        int rentTile = activePlayer.gamePiece.getCurrentTile();
        BoardTile rentT = getBoardTileFromIndex(rentTile);
        Player rentOwner = rentT.getOwner();
        int amount = Rent.getRent(rentTile, rentT.getNumOfHouse()); //check this one g

        if (activePlayer.getCash() >= amount)
        {
            activePlayer.addCash(-(amount));
            messager.NewMessage(amount + " Removed From " + activePlayer.playerName + "'s Cash Pile + L + No Maddiens + Ratio");
            return true; 
        }

        else
        {
            messager.NewMessage(activePlayer.playerName + "Cannot Afford To Pay Rent.");
            return false; 
        }



        //else - gotta sell properties n morgage etc etc. 
        
    }

    /*
    * Function: endTurn
    * Purpose: ends the current players turn
    */
    public void endTurn()
    {
        activePlayerID++;
        if (activePlayerID == players.Length)
        {
            playerIndicator.transform.position += new Vector3(0f, 34f * (activePlayerID - 1), 0f);
            activePlayerID = 0;
        }
        else
        {
            playerIndicator.transform.position -= new Vector3(0f, 34f, 0f);
        }
        doubleTracker = 0;
        UIManager.ToggleRTDButton(true);

        activePlayer = players[activePlayerID];
        messager.NewMessage("Now playing: " + activePlayer.playerName);

        // basic banker AI 
        if(activePlayer == bankerAI)
        {
            float chanceOfButtonPress = 0.7f;
            float randF1 = (float)rand.NextDouble();
            //auto roll dice
            rollDice(true);
            selectedProperty = getBoardTileFromIndex(activePlayer.gamePiece.getCurrentTile());
            // 70% chance of attempting to purchase current property
            if(chanceOfButtonPress > randF1)
            {
                purchase();
            }
            // if the AI's money is less than 300 then 50% to mortgage a random property
            float randF2 = (float)rand.NextDouble();
            if (activePlayer.getCash() < 300)
            {
                if((chanceOfButtonPress - 0.2f) > randF2);
                    int randI = rand.Next(activePlayer.ownedProperties.Count);
                    selectedProperty = activePlayer.ownedProperties[randI];
                    mortgage();
            }
            // if the AI has a property mortgaged but has over 500 then 30% to unmortgage a property
            if ((activePlayer.getCash() > 500) && (activePlayer.mortgagedProperties.Count > 0))
            {
                if((chanceOfButtonPress - 0.4f)> randF2);
                    int randI = rand.Next(activePlayer.mortgagedProperties.Count);
                    selectedProperty = activePlayer.mortgagedProperties[randI];
                    unMortgage();
            }

            // if the AI's money is less than 100 then 70% to sell a random property if all properties are mortgaged
            if ((activePlayer.getCash() < 100) && (activePlayer.ownedProperties.Count < 1) && (activePlayer.mortgagedProperties.Count > 0))
            {
                if(chanceOfButtonPress > randF2);
                    int randI = rand.Next(activePlayer.mortgagedProperties.Count);
                    selectedProperty = activePlayer.mortgagedProperties[randI];
                    sell();
            }
        endTurn();
        }

        //remove bankrupt player
        if(activePlayer.bankrupt)
        {   
            //activePlayer.gamePiece.gameObject.SetActive(false);
            List<Player> tmp = new List<Player>(players);
            tmp.RemoveAt(activePlayerID);
            players = tmp.ToArray();


        }
        if(playersLeft() == 1)
        {
            messager.NewMessage(players[0].playerName + "won the game!");
        }
        UIManager.UpdatePropertyList();
    }

    /*
    * Function: gameUISetup
    * Purpose: sets up game UI
    */
    private void gameUISetup()
    {

        if (gamemode == gameType.TIMED)
        {
            timerText.text = timeLeft.ToString();
            gamemodeText.text = "Time Left";
        }
        else if (gamemode == gameType.STANDARD)
        {
            timerText.text = "";
            gamemodeText.text = "Standard";
        }

        updatePlayers();
    }

    private void updatePlayers()
    {
        string playerNames = "";
        foreach (Player plyr in players)
        {
            playerNames += plyr.playerName + " (??" + plyr.cash + ")" + "\n";
        }
        playerListText.text = playerNames;
    }
}

