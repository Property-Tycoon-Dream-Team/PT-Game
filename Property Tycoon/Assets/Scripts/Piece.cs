using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public string pieceName;
    public bool chosen;
    public int currentTile = 0;
    public int totalTiles = 0;
    private int move = 0;
    public float speed;

    /*
     * Function: Update (MonoBehavior function - called every frame)
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: Checks if move is equal to zero, if not movePiece is run. 
     */

    void Update()
    {   
        if (move == 0){
            return;
        }
        else 
        {
            movePiece(move);
            move = 0; 
        }
    }

    /*
     * Function: moveHelper
     * Parameters: int amount - amount of tiles the piece should be moved
     * Returns: N/A  
     * Purpose: Move the piece to the correct tile depending on the amount. 
     */
    private void moveHelper(int amount)
    {
        BoardTile targetBT = null;
        totalTiles += amount; 
        currentTile = (currentTile % 40 + 40) % 40;
        targetBT = Board.findTile(currentTile);
        transform.position = Vector3.MoveTowards(transform.position, targetBT.transform.position, Time.deltaTime * speed);
    }

    /*
     * Function: movePiece
     * Parameters: int amount - the amount of tiles the piece should be moved. 
     * Returns: N/A  
     * Purpose: Set the value of move equal to amount. 
     */
    public void movePiece(int amount)
    {
        move = amount; 
    }
}
