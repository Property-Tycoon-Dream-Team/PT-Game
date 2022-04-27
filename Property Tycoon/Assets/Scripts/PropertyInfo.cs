using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyInfo
{
    public int cost;
    Player owner;
    public int numOfHouse;
    public bool hotel;
    public propColour pc;
    public bool utility;
    public bool station;
    public bool morgaged = false;
    public int[] rent = new int[5];

    /*
     * Function: checkHotel
     * Parameters: propColour pc - the property colour to check 
     * Returns: boolean value, whether a hotel can be  made
     * Purpose: to check whether a hotel is eligible to be built
     */
    public bool checkHotel(propColour pc)
    {
        // Return whether this property is allowed to have hotel or not
        int currentHouseCount = getNumOfHouse();

        if (!(pc.Equals("STATION") && pc.Equals("UTILITIES")))
        {
            //Checks to see if there are 4 houses on the property ---> Might be the case that you would have to check to see if all 3 properties have 4 houses EACH but not specified...
            if (currentHouseCount == 4)
            {
                return true;
            }
        }

        return false;
    }

    /*
     * Function: setHotel
     * Parameters: bool x - true or false whether or not the property has a hotel on it or not 
     * Returns: N/A
     * Purpose: to assign this property with a hotel
     */
    public void setHotel(bool x)
    {
        hotel = x;
    }

    /*
     * Function: checkUtility
     * Parameters: propColour pc - the property colour to check 
     * Returns: boolean value, whether the property is a utility or not
     * Purpose: to check if the propery is a utility
     */
    bool checkUtility(propColour pc)
    {
        if (pc.Equals("UTILITIES"))
        {
            utility = true;
            return true;
        }
        return false;
    }

    /*
     * Function: checkStation
     * Parameters: propColour pc - the property colour to check 
     * Returns: boolean value, whether the property is a station or not
     * Purpose: to check if the propery is a station
     */
    bool checkStation(propColour pc)
    {
        if (pc.Equals("STATION"))
        {
            station = true;
            return true;
        }
        return false;
    }

    /*
     * Function: getOwner
     * Parameters: N/A
     * Returns: Player instance, who owns this property
     * Purpose: return the owner
     */
    public Player getOwner()
    {
        return owner;
    }

    /*
     * Function: setOwner
     * Parameters: Player p - the new owner of the property
     * Returns: N/A
     * Purpose: sets a new owner
     */
    public void setOwner(Player p)
    {
        // Set owner of this property to p
        owner = p;
    }

    /*
     * Function: removeOwner
     * Parameters: N/A
     * Returns: N/A
     * Purpose: removes the owner form the property
     */
    public void removeOwner()
    {
        owner = null; 
    }

    /*
     * Function: getCost
     * Parameters: N/A
     * Returns: integer value - cost of the property
     * Purpose: gets the cost of the property
     */
    public int getCost()
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
    public int getNumOfHouse()
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
    public void setNumOfHouse(int houses)
    {
        // Set num of houses of this property
        numOfHouse = houses;
    }
    


    /*
     * Function: mortgage
     * Parameters: N/A
     * Returns: N/A
     * Purpose: tags the property as mortaged.
     */
    public void mortgage()
    {
        morgaged = true;
    }

    /*
     * Function: unmortgage
     * Parameters: N/A
     * Returns: N/A
     * Purpose: removes the mortaged tag from the property.
     */
    public void unmortgage()
    {
        morgaged = false;
    }


    /*
     * Function: getPC
     * Parameters: N/A
     * Returns: propColour value - the colour of the property
     * Purpose: return the property colour of this property
     */
    public propColour getPC()
    {
        // Return colour of this property
        return pc;
    }
}
