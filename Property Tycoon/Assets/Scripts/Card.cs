using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Card
{
    public string title;
    public bool isActionComplete = false;
    public abstract string action(Player p);

}
    
