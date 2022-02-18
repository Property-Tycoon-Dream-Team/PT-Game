using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int freeParkingValue;
    public GameObject canvas;
    public GameObject menuCam;
    public GameObject mainCam;
    public Dropdown gamemodeChooser;
    public InputField timeInput;
    public Piece[] pieces;
    Player[] players;
    Player activePlayer;
    float timeLeft;
    CardStack cardStack;
    int doubleTracker = 0;
    gameType gamemode;

    /*
     * Function: rollDice
     * Parameters: bool track - whether or not this dice roll should be tracked 
     * Returns: integer value between 2-12
     * Purpose: used to generate random dice roll and track number of doubles rolled
     */
    int rollDice(bool track)
    {
        Dice dice = new Dice();
        if (track)
        {
            doubleTracker = dice.isDouble ? doubleTracker + 1 : 0;
        }
        return dice.value;
    }

    /*
     * Function: onDropdownChange
     * Parameters: N/A 
     * Returns: N/A
     * Purpose: toggled the timer input for the custom timed gamemode
     */
    public void onDropdownChange()
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
     * Function: startGame
     * Parameters: N/A 
     * Returns: N/A
     * Purpose: called at the very start of the game, initiates everything and starts the round looper
     */
    public void startGame()
    {
        canvas.SetActive(false);
        mainCam.SetActive(true);
        menuCam.SetActive(false);

        gamemode = (gameType) gamemodeChooser.value;

        if (gamemodeChooser.value == 1)
        {
            gamemode = gameType.TIMED;
            if (!float.TryParse(timeInput.text, out timeLeft) || timeLeft < 30f)
            {
                timeLeft = 30f;
            }
        }

        playerSetup();
        // Set up board and properties
        // Set up card decks

        // Starts turn looping
        while (playersLeft() > 1)
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
    int playersLeft()
    {
        // Return the amount of players left (you can look inside each Player in players array and check the bankrupt bool value)
        return 0;
    }

    /*
     * Function: playerSetup
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: sets up all the players for the game
     */
    void playerSetup()
    {
        //In menu:
        //  Get amount of players
        //  Get players to choose pieces & names
        //  Add AI player (banker) and Bchoose last piece (or random piece if multiple available)
        //  Get players to roll dice to choose order
        //  Give all players 1500£
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
     * Purpose: moves the player 'amount' amount of spaces around the board
     */
    void movePiece(int amount)
    {
        // Move piece of active player amount of spaces (makes sure to update the players numOfTilesMoved)
    }

    /*
     * Function: purchase
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: purchases the property that the current player lands on
     */
    void purchase()
    {
        // Purchase property (only allowed after 1 circuit)
    }

    /*
     * Function: upgrade
     * Parameters: N/A 
     * Returns: N/A 
     * Purpose: upgrades property to houses then hotels
     */
    void upgrade()
    {
        // Upgrade to houses then hotels (follow ruleset)
    }

    /*
    * Function: auction
    * Parameters: N/A 
    * Returns: Player value - who won the bid 
    * Purpose: upgrades property to houses then hotels
    */
    Player auction()
    {
        // Run when player does not purchase, gives property to highest bidder
        // Remains unsold if no bids
        return null;
    }

    /*
    * Function: mortgage
    * Parameters: N/A 
    * Returns: N/A
    * Purpose: mortgages a property
    */
    void mortgage()
    {
        // If need to raise funds, gain half value of original property - cant receive rent from it (can be unmortgaged)
    }

    /*
    * Function: unMortgage
    * Parameters: N/A 
    * Returns: N/A
    * Purpose: unmortgages a property
    */
    void unMortgage()
    {
        // Pay half original value of property, rent reenabled
    }

    /*
    * Function: sell
    * Parameters: N/A 
    * Returns: N/A
    * Purpose: sells a property
    */
    void sell()
    {
        // Logic to sell property for full value (if mortgaged get half) - can call unMortgage()
    }
}
