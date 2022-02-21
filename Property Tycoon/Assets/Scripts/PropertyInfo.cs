using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyInfo
{
    int cost;
    Player owner;
    int numOfHouse;
    bool hotel;
    propColour pc;
    bool utility;
    bool station;

    /*
     * Function: checkHotel
     * Parameters: propColour pc - the property colour to check 
     * Returns: boolean value, whether a hotel can be  made
     * Purpose: to check whether a hotel is eligible to be built
     */
    bool checkHotel(propColour pc)
    {
        // Return whether this property is allowed to have hotel or not
        return false;
    }

    /*
     * Function: getOwner
     * Parameters: N/A
     * Returns: Player instance, who owns this property
     * Purpose: return the owner
     */
    Player getOwner()
    {
        return owner;
    }

    /*
     * Function: setOwner
     * Parameters: Player p - the new owner of the property
     * Returns: N/A
     * Purpose: sets a new owner
     */
    void setOwner(Player p)
    {
        // Set owner of this property to p
    }

    /*
     * Function: getCost
     * Parameters: N/A
     * Returns: integer value - cost of the property
     * Purpose: gets the cost of the property
     */
    int getCost()
    {
        // Return the cost of this property
        return cost;
    }

    /*
     * Function: getNumOfHouse
     * Parameters: N/A
     * Returns: integer value - number of houses on this property
     * Purpose: return the number of houses on this property
     */
    int getNumOfHouse()
    {
        // Return num of houses on this property
        return numOfHouse;
    }

    /*
     * Function: setNumOfHouse
     * Parameters: int houses - the new number of houses
     * Returns: N/A
     * Purpose: sets the num of houses on this property
     */
    void setNumOfHouse(int houses)
    {
        // Set num of houses of this property
    }
}
