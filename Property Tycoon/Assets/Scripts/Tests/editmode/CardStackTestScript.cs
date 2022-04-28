using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardStackTestScript
{
    private CardStack stack;
    private CardStack stack2;
    private Card card1;
    private Card card2;
    private Card card3;
    private Card card4;
    private Card card5;
    private Card card6;
    private Card card7;
    private Card card8;
    private Card card9;
    private Card card10;

    [SetUp]
    public void SetUp()
    {
        stack = new CardStack();
        stack2 = new CardStack();
        card1 = new Card();
        card2 = new Card();
        card3 = new Card();
        card4 = new Card();
        card5 = new Card();
        card6 = new Card();
        card7 = new Card();
        card8 = new Card();
        card9 = new Card();
        card10 = new Card();
    }

    [Test]
    public void TestPopNextCard()
    {
        stack.popNextCard();
    }

    [Test]
    public void TestRetrunActiveCard()
    {
        stack.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };
        stack.activeCard = stack.popNextCard();
        Assert.IsFalse(stack.returnActiveCard());

        stack.activeCard = stack.popNextCard();
        stack.activeCard.isActionComplete = true;
        Assert.IsTrue(stack.returnActiveCard());
        Assert.Null(stack.activeCard);
    }

    [Test]
    public void TestShuffle()
    {   
        stack.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10};
        stack2.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };

        stack.shuffle();

        Assert.AreNotEqual(stack.cards, stack2.cards);
    }
}