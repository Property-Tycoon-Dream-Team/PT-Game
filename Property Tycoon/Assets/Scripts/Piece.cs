using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public string pieceName;
    public Transform location;
    public GameObject target;
    public bool chosen;
    public int currentTile = 0;
    public int totalTiles = 0;
    public float speed;
    private GameManager gm;
    bool move = false;

    /*
     * Function: Update (MonoBehavior function - called every frame)
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: Checks if move is equal to zero, if not movePiece is run. 
     */
    
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
    }
    void Update()
    {   
        while (move)
        {
            moveHelper();
        }
    }

    /*
     * Function: moveHelper
     * Parameters: int amount - amount of tiles the piece should be moved
     * Returns: N/A  
     * Purpose: Move the piece to the correct tile depending on the amount. 
     */
    public void moveHelper()
    {
        Debug.Log((gm.getTileObject(currentTile)).name);
        target = gm.getTileObject(currentTile);
        transform.position = target.transform.position + new Vector3(0f, 0.1f, 0f);
        move = false;
    }

    /*
     * Function: movePiece
     * Parameters: int amount - the amount of tiles the piece should be moved. 
     * Returns: N/A  
     * Purpose: Set the value of move equal to amount. 
     */
    public void movePiece(int amount)
    {
        totalTiles += amount; 
        currentTile = (totalTiles % 40 + 40) % 40;
        move = true; 
    }
    
    /*
     * Function: getCurrentTile
     * Parameters: N/A
     * Returns: int currentTile
     * Purpose: returns the index of the current tile the gamePiece is on  
     */
    public int getCurrentTile()
    {
        return currentTile; 
    }

    /*
     * Function: getTotalTiles
     * Parameters: N/A
     * Returns: int totalTiles
     * Purpose: returns the total amount of tiles the gamePiece has moved
     */
    public int getTotalTiles(){
        return totalTiles;
    }
}
