using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardStackTestScript
{
    private CardStack stack;
    private Card card1;
    private Card card2;
    private Card card3;
    private Card card4;
    private Card card5;

    [SetUp]
    public void SetUp()
    {
        stack = new CardStack();
        card1 = new Card();
        card2 = new Card();
        card3 = new Card();
        card4 = new Card();
        card5 = new Card();
    }

    [Test]
    public void TestPopNextCard()
    {
        stack.popNextCard();
    }

    [Test]
    public void TestRetrunActiveCard()
    {
        stack.activeCard.isActionComplete = false;
        Assert.IsFalse(stack.returnActiveCard());

        stack.activeCard.isActionComplete = true;
        Assert.IsTrue(stack.returnActiveCard());
        Assert.That(stack.activeCard.isActionComplete == false);
        Assert.Null(stack.activeCard);
    }

    [Test]
    public void TestShuffle()
    {
        CardStack stack2 = new CardStack();

        stack.cards[0] = card1;
        stack.cards[1] = card2;
        stack.cards[2] = card3;
        stack.cards[3] = card4;
        stack.cards[4] = card5;

        for (int i = 0; i < stack.cards.Length; i++)
        {
            stack2.cards[i] = stack.cards[i];
        }

        stack.shuffle();
        Assert.AreNotEqual(stack.cards, stack2.cards);
    }
}