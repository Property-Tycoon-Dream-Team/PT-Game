using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public static class Rent{

public static int[][] rentValues = {
        new int[] {0},
        new int[] {2, 10, 30, 90, 160, 250}, //prop
        new int[] {0},
        new int[] {4, 20, 60, 180, 320, 450},
        new int[] {0}, //income tax
        new int[] {25, 50, 100, 200}, //station 
        new int[] {6, 30, 70, 270, 400, 550},
        new int[] {0},
        new int[] {6,		30,	90,	270,	400,	550},
        new int[] {8, 40, 100, 300, 450, 600},
        new int[] {0},
        new int[] {10,50	,150	,450	,625	,750},
        new int[] {0},
        new int[] {10,		50,	150,	450,	625,	750},
        new int[] {12,		60,	180,	500,	700,	900},
        new int[] {25, 50, 100, 200},
        new int[] {14,		70,	200	,550,	750,	950},
        new int[] {0},
        new int[] {14,		70,	200,	550,	750,	950},
        new int[] {16,		80,	220,	600,	800	,1000},
        new int[] {0},
        new int[] {18	,	90	,250	,700,	875	,1050},
        new int[] {0},
        new int[] {18,		90,	250	,700,	875,	1050},
        new int[] {20	,	100	,300,	750,	925,	1100},
        new int[] {25, 50, 100, 200},
        new int[] {22,		110,	330,	800,	975,	1150},
        new int[] {22	,	110	,330,	800,	975,	1150},
        new int[] {0},
        new int[] {22,		120	,360,	850,	1025,	1200},
        new int[] {0}, //jail
        new int[] {26,		130	,390,	900,	1100,	1275},
        new int[] {26,		130,	390,	900,	1100,	1275},
        new int[] {28,		150,	450	,1000,	1200,	1400}, 
        new int[] {25, 50, 100, 200},
        new int[] {0},
        new int[] {35,		175,	500	,1100,	1300,	1500},
        new int[] {0},
        new int[] {50	,	200,	600,	1400,	1700,	2000},
        }; 

    public static int getRent(int index, int houses){
        return rentValues[index][houses];
    }
}
