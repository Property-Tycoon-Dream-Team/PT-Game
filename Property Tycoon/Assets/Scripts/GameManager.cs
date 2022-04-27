using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int freeParkingValue;
    public GameObject mainMenu;

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
    public PropertyInfo selectedProperty;

    private Player[] players;
    private int activePlayerID;
    private Player activePlayer;
    private float timeLeft;
    private CardStack potLuckStack;
    private CardStack opportunityStack;
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

        messager.NewMessage(activePlayer.playerName + " rolled: " + dice.value);

        activePlayer.gamePiece.movePiece(dice.value);
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

        // Starts turn looping
        while (playersLeft() > 1 && true == false)
        {
            round();
        }

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
                players[players.Length - 1].playerName = "Bossman (AI Banker)";
                players[players.Length - 1].ai = true;

                Piece assignedPiece = findSparePiece();
                assignedPiece.chosen = true;
                players[i].gamePiece = assignedPiece;

                players[players.Length - 1].cash = 1500;
            }
        }
        activePlayerID = 0;
        activePlayer = players[activePlayerID];
        
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
     * Function: round
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: runs the main part of the game round by round
     */
    void round()
    {
        // Cycle through player list, giving them turn (DO NOT CODE)
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
        if (activePlayer.gamePiece.getTotalTiles() >= 40)
        {
            int cTile = activePlayer.gamePiece.getCurrentTile();
            if (activePlayer.addToProperties(Board.findTile(cTile)))
            {
                return true;
            }
            else return false;  
        }
        else return false; 
    }

    /*
     * Function: upgrade
     * Parameters: BoardTile prop - The desired property to be upgraded by the player 
     * Returns: N/A 
     * Purpose: upgrades property to houses then hotels
     */
    public void upgrade()
    {
        BoardTile prop = tiles[0]; // make current tile?!

        PropertyInfo pi = prop.propertyInfo;
        propColour currentpc = pi.getPC();
        int count = 0;
        foreach (var property in activePlayer.ownedProperties)
        {
            //checking to see if player has all 3 property of the same colour before being allowed to upgrade
            if (property.propertyInfo.getPC() == currentpc)
            {
                count++;
                if (count == 3)
                {
                    //checking if a hotel needs to be made or a house
                    if (!pi.checkHotel(currentpc))
                    {
                        int currentHouses = pi.getNumOfHouse();
                        pi.setNumOfHouse(currentHouses + 1);
                    }
                    else
                    {
                        pi.setHotel(true);
                    }
                }
            }
        }
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
        BoardTile bt = tiles[0]; // make current tile?!
        if (activePlayer.addToMorgagedProperties(bt))
        {
            return true;
        }
        else return false;
    }

    /*
    * Function: unMortgage
    * Parameters: BoardTile bt - the property in which is being unmortaged.
    * Returns: a bool value, if the player succesfully unmortgaged the property. 
    * Purpose: calls the removeMortgage function for the active player. 
    */
    public bool unMortgage()
    {
        BoardTile bt = tiles[0]; // make current tile?!
        if (activePlayer.removeMortgage(bt))
        {
            return true;
        }
        else return false;
    }

    /*
    * Function: sell
    * Parameters: BoardTile bt - the property in which is being sold.
    * Returns: a bool value, if the player succesfully sells the property. 
    * Purpose: calls the sellProperty for the active player. 
    */
    public bool sell()
    {
        BoardTile bt = tiles[0]; // make current tile?!
        if (activePlayer.sellProperty(bt))
        {
            return true;
        }
        else return false;
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

        activePlayer = players[activePlayerID];
        messager.NewMessage("Now playing: " + activePlayer.playerName);
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

        string playerNames = "";
        foreach (Player plyr in players)
        {
            playerNames += plyr.playerName + "\n";
        }
        playerListText.text = playerNames;
    }
}
