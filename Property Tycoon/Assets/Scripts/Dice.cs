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
        // Randomises 2 1-6 values, adds them - puts value in value (if double, set double true else false) Random.Range(1,7);
    }
}
