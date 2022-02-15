using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Bank
{
    static int money 
    {
        get
        {
            return money;
        }
        set
        {
            // Josh double check this get/set logic you pillock
            if (value <= 1000)
            {
                value = 50000;
            }
        }
    }
}
