using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Board
{
    
    
    public static BoardTile[] boardSquares;

    /*
     * Function: getColouredProperties
     * Parameters: propColour pc - colour of properties to retrieve 
     * Returns: PropertyInfo array containing all the properties of colour 'pc'
     * Purpose: used to generate random dice roll and track number of doubles rolled
     */
    static PropertyInfo[] getColouredProperties(propColour pc)
    {
        // Return all properties of colour pc
        return null;
    }

    static public BoardTile findTile(int index)
    {
        return boardSquares[index];
    }
}
