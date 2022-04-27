using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GameManagerTestScript
{ 
   
    [Test]
    public void TestOnPlayerInfoChange()
    {
        GameManager gm = new GameManager(); 
        gm.onPlayerInfoChange();
    }

    [Test]
    public void TestRollDice()
    {
        var gm = new GameManager();
        gm.rollDice(true);
    }

    [Test]
    public void TestGetTileObject()
    {
        GameManager gm = new GameManager();
        gm.getTileObject(5);
    }

    [Test]
    public void TestOnGamemodeDropdownChange()
    {
        GameManager gm = new GameManager();
        gm.onGamemodeDropdownChange();
    }

    [Test]
    public void TestOnSliderChange()
    {
        GameManager gm = new GameManager();
        gm.onSliderChange();
    }

    [Test]
    public void TestStartGame()
    {
        GameManager gm = new GameManager();
        gm.startGame();
    }

    [Test]
    public void TestPlayersLeft()
    {
        GameManager gm = new GameManager();
        gm.playersLeft();
    }

    [Test]
    public void TestPlayerSetupe()
    {
        GameManager gm = new GameManager();
        gm.onSliderChange();
    }

    [Test]
    public void Testpurchase()
    {
        GameManager gm = new GameManager();
        gm.purchase();
    }

    [Test]
    public void TestUpgrade()
    {
        GameManager gm = new GameManager();
        gm.upgrade();
    }

    [Test]
    public void TestAuction()
    {
        GameManager gm = new GameManager();
        gm.auction();
    }

    [Test]
    public void Testmortgage()
    {
        GameManager gm = new GameManager();
        gm.mortgage();
    }

    [Test]
    public void TestUnMortgage()
    {
        GameManager gm = new GameManager();
        gm.unMortgage();
    }

    [Test]
    public void TestSell()
    {
        GameManager gm = new GameManager();
        gm.sell();
    }

    [Test]
    public void TestEndTurn()
    {
        GameManager gm = new GameManager();
        gm.endTurn();
    }
}
