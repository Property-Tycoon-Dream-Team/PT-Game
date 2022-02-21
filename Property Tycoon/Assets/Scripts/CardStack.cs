using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack
{
    Card[] cards;
    int type;
    int pos = 0;

    /*
     * Function: popNextCard
     * Parameters: N/A
     * Returns: Card instance containing the information about the card drawn
     * Purpose: emulates picking up a card
     */
    Card popNextCard()
    {
        // Give next card, put card on back of pile (in higher logic set Player jailCard++ if is jail card)
        return cards[pos++]; // edit with modulus 
    }

    /*
     * Function: shuffle
     * Parameters: N/A
     * Returns: N/A
     * Purpose: shuffles the cards in this deck
     */
    void shuffle()
    {
        // Shuffle cards
    }
}
