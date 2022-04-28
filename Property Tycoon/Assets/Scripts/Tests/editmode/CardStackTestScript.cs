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
        stack.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };
        stack.activeCard = stack.popNextCard();
        Assert.That(stack.cards[0] == card2);
        Assert.That(stack.cards[stack.cards.Length - 1] == null);

        stack.returnActiveCard();
        stack.activeCard = stack.popNextCard();
        Assert.That(stack.cards[0] == card3);
        Assert.That(stack.cards[stack.cards.Length - 2] == card1);
        Assert.That(stack.cards[stack.cards.Length - 1] == null);
    }

    [Test]
    public void TestRetrunActiveCard()
    {
        stack.cards = new Card[10] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };
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
        card1.title = "Test1";
        card2.title = "Test2";
        card3.title = "Test3";
        card4.title = "Test4";
        card5.title = "Test5";
        card6.title = "Test6";
        card7.title = "Test7";
        card8.title = "Test8";
        card9.title = "Test9";
        card10.title = "Test10";

        stack.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };
        stack2.cards = new Card[] { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };

        stack.shuffle();
        stack2.shuffle();

        for (int i = 0; i < stack.cards.Length; i++) {
            if (stack.cards[i].title != stack2.cards[i].title)
            {
                Assert.AreNotEqual(stack.cards[i].title, stack2.cards[i].title);
                break;
            }
        }
    }
}