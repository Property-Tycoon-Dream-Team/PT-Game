using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rent
{   
    int[][] rentValues = {
        new int[] {2, 10, 30, 90, 160, 250}, 
        new int[] {0},
        new int[] {4, 20, 60, 280, 320, 450},
        new int[] {0},
        new int[] {0},};

    public int getRent(int index, int houses){
        return rentValues[index][houses];
    }
}
