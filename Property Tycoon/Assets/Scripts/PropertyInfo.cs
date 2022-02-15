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

    bool checkHotel(propColour pc)
    {
        // Return whether this property is allowed to have hotel or not
        return false;
    }

    Player getOwner()
    {
        // Return the owner of this property
        return null;
    }

    int getCost()
    {
        // Return the cost of this property
        return 0;
    }

    int getNumOfHouse()
    {
        // Return num of houses on this property
        return 0;
    }

    void setNumOfHouse()
    {
        // Set num of houses of this property
    }

    void setOwner(Player p)
    {
        // Set owner of this property to p
    }
}
