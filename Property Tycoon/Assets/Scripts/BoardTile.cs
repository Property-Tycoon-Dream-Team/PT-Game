using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public PropertyInfo propertyInfo;
    public string tileName;
    public tileType type;

    /*
     * Function: getPropertyInfo
     * Parameters: N/A
     * Returns: propInfo class - the property info relating to this tile
     * Purpose: to return details of the property on this tile
     */
    public PropertyInfo getPropertyInfo()
    {
        return propertyInfo;
        // Return property info for this tile
    }
}
