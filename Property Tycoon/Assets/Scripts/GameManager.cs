using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Player[] players;
    Player activePlayer;
    public int freeParkingValue;
    public GameObject canvas;
    public GameObject menuCam;
    public GameObject mainCam;
    public Dropdown gamemodeChooser;
    public InputField timeInput;
    float timeLeft;
    CardStack cardStack;
    int doubleTracker = 0;
    gameType gamemode;

    int rollDice(bool track)
    {
        Dice dice = new Dice();
        if (track)
        {
            doubleTracker = dice.isDouble ? doubleTracker + 1 : 0;
        }
        return dice.value;
    }

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

    public void startGame()
    {
        canvas.SetActive(false);
        mainCam.SetActive(true);
        menuCam.SetActive(false);

        if (gamemodeChooser.value == 0)
        {
            gamemode = gameType.STANDARD;
        } 
        else if (gamemodeChooser.value == 1)
        {
            gamemode = gameType.TIMED;
            if (!float.TryParse(timeInput.text, out timeLeft) || timeLeft < 30f)
            {
                timeLeft = 30f;
            }
        }
        else if (gamemodeChooser.value == 2)
        {
            gamemode = gameType.HORROR;
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

    int playersLeft()
    {
        // Return the amount of players left (you can look inside each Player in players array and check the bankrupt bool value)
        return 0;
    }

    void playerSetup()
    {
        //In menu:
        //  Get amount of players
        //  Get players to choose pieces & names
        //  Add AI player (banker) and Bchoose last piece (or random piece if multiple available)
        //  Get players to roll dice to choose order
        //  Give all players 1500£
    }

    void round()
    {
        // Cycle through player list, giving them turn (DO NOT CODE)
    }

    void movePiece(int amount)
    {
        // Move piece of active player amount of spaces (makes sure to update the players numOfTilesMoved)
    }

    void purchase()
    {
        // Purchase property (only allowed after 1 circuit)
    }

    void upgrade()
    {
        // Upgrade to houses then hotels (follow ruleset)
    }

    Player auction()
    {
        // Run when player does not purchase, gives property to highest bidder
        // Remains unsold if no bids
        return null;
    }

    void mortgage()
    {
        // If need to raise funds, gain half value of original property - cant receive rent from it (can be unmortgaged)
    }

    void unMortgage()
    {
        // Pay half original value of property, rent reenabled
    }

    void sell()
    {
        // Logic to sell property for full value (if mortgaged get half) - can call unMortgage()
    }
}
