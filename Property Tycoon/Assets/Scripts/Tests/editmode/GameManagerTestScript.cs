using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTestScript
{
    private GameManager gm;

    [SetUp]
    public void SetUp()
    {
        gm = new GameManager();
    }
   
    [Test]
    public void TestRollDice()
    {
        gm.rollDice(true);
    }

    [Test]
    public void TestAddToFreeParking()
    {
        int amount = 50;
        gm.addToFreeParking(amount);
        Assert.That(gm.freeParkingValue >= amount);

    }

    [Test]
    public void TestPlayersLeft()
    {
        Player player = new Player();
        Player player2 = new Player();
        gm.players = new Player[] { player, player2 };
        Assert.That(gm.playersLeft() == 2);       
    }

    [Test]
    public void Testpurchase()
    {
        gm.purchase();
    }

    [Test]
    public void TestUpgrade()
    {
        gm.upgrade();
    }

    [Test]
    public void TestAuction()
    {
        gm.auction();
    }

    [Test]
    public void Testmortgage()
    {
        Player p = new Player();
        BoardTile bt = new BoardTile();
        gm.tiles = new BoardTile[] {bt};
        gm.messager = new SystemMsgs();
        gm.selectedProperty = gm.tiles[0];
        bt.cost = 500;
        p.cash = 0;
        gm.activePlayer = p;
        Assert.IsTrue(gm.mortgage());

    }

    [Test]
    public void TestUnMortgage()
    {
        gm.unMortgage();
    }

    [Test]
    public void TestSell()
    {
        BoardTile bt = new BoardTile();
        gm.selectedProperty = bt;
        Player p = new Player();
        p.ownedProperties.Add(bt);
        gm.activePlayer = p;
        Assert.IsTrue(gm.sell());
    }

    [Test]
    public void TestEndTurn()
    {
        Player p1 = new Player();
        Player p2 = new Player();
        Player p3 = new Player();

        gm.players = new Player[] { p1, p2, p3 };
        gm.activePlayer = p1;
        gm.endTurn();
        Assert.That(gm.activePlayer == p2);
        
    }
}
