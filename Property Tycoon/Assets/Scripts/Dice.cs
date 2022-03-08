using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice
{
    public int value;
    public bool isDouble;

    /*
     * Function: CLASS CONSTRUCTOR
     * Parameters: N/A
     * Returns: N/A
     * Purpose: emulates rolling 2 dice
     */
    public Dice()
    {
        int dice1 = Random.Range(1, 7);
        int dice2 = Random.Range(1, 7);
        value = dice1 + dice2;
        if (dice1 == dice2)
        {
            isDouble = true;
        }
        else
        {
            isDouble = false;
        }
        // Randomises 2 1-6 values, adds them - puts value in value (if double, set double true else false) Random.Range(1,7);
    }
}
