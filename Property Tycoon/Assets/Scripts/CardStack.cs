using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack
{
    Card[] cards;
    Card temp;
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
        // Shuffles cards

        // Runs the process 100 times to ensure an effective shuffle
        for (int i = 0; i < 100; i++)
        {
            // Generates two random numbers between 0 and the length of the card deck
            int randomNumber1 = Random.Range(0, cards.Length);
            int randomNumber2 = Random.Range(0, cards.Length);

            // Swaps the contents of 'randomNumber1' with 'randomNumber2'
            temp = cards[randomNumber1]; 
            cards[randomNumber1] = cards[randomNumber2];
            cards[randomNumber2] = temp;
        }   
    }
}
