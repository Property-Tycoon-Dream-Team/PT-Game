using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public Card[] cards;
    public Card activeCard;
    int type;
    int pos = 0;

    /*
     * Function: popNextCard
     * Parameters: N/A
     * Returns: Card instance containing the information about the card drawn
     * Purpose: emulates picking up a card
     */
   public Card popNextCard()
    {
        // Give next card (in higher logic set Player jailCard++ if is jail card)

    
        // Stores popped card in a temporary state until its action has been completed
       activeCard = cards[0];

        // Shifts all other cards by 1 to the left so a new card can be at the top of the pile
        for (int i = 0; i < (cards.Length - 1); i++) // card.length is subtracted by 1 to accomidate for the 0 index which prevents an out of bounds error
        {
            cards[i] = cards[i + 1]; 
        }
        // Sets the final card in the deck to null after the shift to prevent a duplicate card 
        cards[cards.Length - 1] = null; // card.length is subtracted by 1 to accomidate for the 0 index which prevents an out of bounds error 

        // Returns the popped card
        return activeCard;
    }

    public bool returnActiveCard()
    {
        // Returns card to bottom of deck 

        // Checks to see if the action is conplete
        if (activeCard.isActionComplete)
        {
            // Returns the card to the bottom of the pile and sets 'isActionComplete' back to false before setting 'activeCard' back to being empty
            cards[cards.Length - 1] = activeCard; // card.length is subtracted by 1 to accomidate for the 0 index which prevents an out of bounds error
            activeCard.isActionComplete = false; 
            activeCard = null;
            return true;
        }
        else return false;
    }

    /*
     * Function: shuffle
     * Parameters: N/A
     * Returns: N/A
     * Purpose: shuffles the cards in this deck
     */
    public void shuffle()
    {
        Card temp;
        // Shuffles cards

        // Runs the process 100 times to ensure an effective shuffle
        for (int i = 0; i < 100; i++)
        {
            // Generates two random numbers between 0 and the length of the card deck
            int randomNumber1 = Random.Range(0, (cards.Length - 1)); // card.length is subtracted by 1 to accomidate for the 0 index which prevents an out of bounds error
            int randomNumber2 = Random.Range(0, (cards.Length - 1)); // card.length is subtracted by 1 to accomidate for the 0 index which prevents an out of bounds error

            // Swaps the contents of 'randomNumber1' with 'randomNumber2'
            temp = cards[randomNumber1]; 
            cards[randomNumber1] = cards[randomNumber2];
            cards[randomNumber2] = temp;
        }   
    }

}
