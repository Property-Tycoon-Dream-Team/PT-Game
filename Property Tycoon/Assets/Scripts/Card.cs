using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Card
{
    string title;
    public abstract string action(Player p);
}
