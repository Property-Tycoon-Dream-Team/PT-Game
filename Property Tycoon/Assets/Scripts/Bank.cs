using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Bank
{
    static int money = 50000;
    static public int Money
    {
        get
        {
            return money;
        }
        set
        {
            if (value <= 1000)
            {
                money = 50000;
            }
        }
    }
}
