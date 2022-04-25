using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public string pieceName;
    public Transform trans;
    public bool chosen;
    public int currentTile = 0;
    public int totalTiles = 0;
    private int move = 0;
    public float speed = 100.5f;
    private GameManager gm;

    /*
     * Function: Update (MonoBehavior function - called every frame)
     * Parameters: N/A 
     * Returns: N/A  
     * Purpose: Checks if move is equal to zero, if not movePiece is run. 
     */
    
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManager>();
        Debug.Log(gm);
    }
    void Update()
    {   
        if (move == 0){
            return;
        }
        else 
        {
            moveHelper(move);
            
        }
    }

    /*
     * Function: moveHelper
     * Parameters: int amount - amount of tiles the piece should be moved
     * Returns: N/A  
     * Purpose: Move the piece to the correct tile depending on the amount. 
     */
    public void moveHelper(int amount)
    {
        totalTiles += amount; 
        currentTile = (totalTiles % 40 + 40) % 40;
        Debug.Log(pieceName);
        //transform.position = Vector3.MoveTowards(transform.position, gm.getTileObject(currentTile).transform.position, Time.deltaTime * speed);
        trans.position += new Vector3(0f, 0f, speed * Time.deltaTime);
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
