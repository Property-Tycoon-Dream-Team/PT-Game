using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTileTestScript
{

    private BoardTile tile;

    [SetUp]
    public void SetUp()
    {
        tile = new BoardTile();
    }

    [Test]
    public void TestGetTileName()
    {
        tile.tileName = "Test";
        Assert.AreEqual("Test", tile.getTileName());
    }

    [Test]
    public void TestGetCost()
    {
        tile.cost = 0;
        Assert.That(tile.getCost() == 0);

        tile.cost = 500;
        Assert.That(tile.getCost() == 500);

        tile.cost = 1000;
        Assert.That(tile.getCost() == 1000);
    }

    [Test]
    public void TestSetOwner()
    {
        Player player = new Player();
        tile.setOwner(player);
        Assert.That(tile.getOwner().Equals(player));
    }

    [Test]
    public void TestGetOwner()
    {
        Player player = new Player();
        tile.setOwner(player);
        Assert.That(tile.getOwner().Equals(player));
    }

    [Test]
    public void TestRemoveOwner()
    {
        Player player = new Player();
        tile.setOwner(player);
        tile.removeOwner();
        Assert.That(tile.getOwner() == null);
    }

    [Test] 
    public void TestIncreaseNumOfHouses()
    {
        tile.numOfHouse = 1;
        tile.increaseNumOfHouse();
        Assert.That(tile.numOfHouse == 2);
    }

    [Test]
    public void TestDecreaseNumOfHouses()
    {
        tile.numOfHouse = 1;
        tile.decreaseNumOfHouse();
        Assert.That(tile.numOfHouse == 0);
    }

    [Test]
    public void TestChangeMortgageStatus()
    {
        tile.changeMortgageStatus();
        Assert.IsTrue(tile.mortgaged);
        tile.changeMortgageStatus();
        Assert.IsFalse(tile.mortgaged);
    }

    [Test]
    public void TestGetPC()
    {
        tile.pc = propColour.BLUE;
        Assert.That(tile.getPC() == propColour.BLUE);
    }
}
