using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Piece gamePiece;
    public string playerName;
    public bool ai;
    public bool jailed;
    public int jailCards;
    public int cash;
    public List<BoardTile> ownedProperties = new List<BoardTile>();
    public List<BoardTile> mortgagedProperties = new List<BoardTile>();
    public bool bankrupt = false;
    public SystemMsgs messager;

    /*
     * Function: getBankrupt
     * Parameters: N/A
     * Returns: a bool value, if the player is bankrupt. 
     * Purpose: to find if the player is still active in the game. 
     */
    public bool getBankrupt()
    {
        return bankrupt;
    }

    /*
     * Function: addToProperties
     * Parameters: BoardTile bt, a tile in which the player is adding to their inventory. 
     * Returns: a bool value, if the player succesfully obtained the board tile. 
     * Purpose: Used to purchase a property or simply obtaining a property via cards, auction etc. 
     */
    public bool addToProperties(BoardTile bt)
    {
        // check if the property is already owned. 
        if ((ownedProperties.Contains(bt)) || (cash < bt.getCost())){
            return false; 
        }
        // adds property to the property list.
        else
        {
            ownedProperties.Add(bt);
            // remove property value from players cash pile.
            addCash(-(bt.getCost()));
            bt.setOwner(this);

            return true; 
        }
    }

    /*
     * Function: addToMorgagedProperties
     * Parameters: BoardTile bt, a tile in which the player is mortgaging.  
     * Returns: a bool value, if the player succesfully mortgaged the property. 
     * Purpose: Used to mortgage a property to get some cash. 
     */
    public bool addToMortgagedProperties(BoardTile bt)
    {
        // check if the player owns the property and if the property is already mortgaged.
        if ((!ownedProperties.Contains(bt)) || (mortgagedProperties.Contains(bt)))
        {
            return false;
        }
        else
        {
            // remove from owned properties, add mortgaged tag to propertyInfo, add to mortgaged properties.
            ownedProperties.Remove(bt);
            bt.changeMortgageStatus();
            mortgagedProperties.Add(bt);

            // add half of the properties value to players cash pile. 
            addCash((bt.getCost()) / 2);
            return true;
        }
    }

    /*
     * Function: removeMortgage
     * Parameters: BoardTile bt, a tile in which the player is unmortgaging.  
     * Returns: a bool value, if the player succesfully unmortgaged the property. 
     * Purpose: player can obtain their property back from being mortgaged.
     */
    public bool removeMortgage(BoardTile bt)
    {   
        // check if property is mortgaged and if the player has enough cash to unmortgage. 
        if((cash < (bt.getCost())/2) || (!mortgagedProperties.Contains(bt)))
        {
            return false; 
        }
        // remove property from mortgagedProperties, remmove mortgage tag from propertyInfo, add property to ownedProperties.
        mortgagedProperties.Remove(bt);
        bt.changeMortgageStatus();
        ownedProperties.Add(bt);
        bt.setOwner(this);
        // add half propery value to players cash. 
        addCash(-((bt.getCost())/2));
        return true; 
    }

    /*
     * Function: sellProperty
     * Parameters: BoardTile bt, a tile in which the player is selling.
     * Returns: a bool value, if the player succesfully sells the property. 
     * Purpose: player sells a owned or mortgaged property to get some cash. 
     */
    public bool sellProperty(BoardTile bt)
    {
        // check if the property is mortgaged. 
        if(mortgagedProperties.Contains(bt))
        {   
            // remove from mortgaged list, remove mortgage tag from propertyInfo, adds half of property value to cash pile.
            mortgagedProperties.Remove(bt);
            bt.mortgaged = false;
            bt.removeOwner();
            addCash((bt.getCost())/2);
            return true; 
        }
        // check if property is in ownedProperties list.
        if(ownedProperties.Contains(bt))
        {
            // remove from properties list, adds cash to cash pile. 
            ownedProperties.Remove(bt);
            bt.removeOwner();
            addCash(bt.getCost());
            return true;
        }
        else return false;
    }


    /*
     * Function: addCash
     * Parameters: amt, the amount of cash to add/ remove from cash pile. 
     * Returns: N/A
     * Purpose: add/ remove money from player cash pile.
     */
    public void addCash(int amt)
    {
        cash += amt;
    }
    /*
     * Function: getCash
     * Parameters: N/A
     * Returns: the players amount of cash
     * Purpose: get the players current cash amount
     */
    public int getCash()
    {
        return cash;
    }
}
