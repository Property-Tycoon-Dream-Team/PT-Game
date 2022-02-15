using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack
{
    Card[] cards;
    int type;

    public CardStack()
    {
        shuffle();
    }

    Card popNextCard()
    {
        // Give next card, put card on back of pile (in higher logic set Player jailCard++ if is jail card)
        return null;
    }

    Card[] shuffle()
    {
        // Shuffle cards
        return null;
    }
}
