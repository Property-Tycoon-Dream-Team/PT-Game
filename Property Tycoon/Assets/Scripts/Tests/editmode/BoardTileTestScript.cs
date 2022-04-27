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
        Assert.AreEqual("Test", tile.tileName);
    }

    [Test]
    public void TestGetCost()
    {
        tile.cost = 0;
        Assert.That(tile.cost == 0);

        tile.cost = 500;
        Assert.That(tile.cost == 500);

        tile.cost = 1000;
        Assert.That(tile.cost == 1000);
    }

    [Test]
    public void TestGetOwner()
    {
        Player player = new Player();
        tile.setOwner(player);
        Assert.That(tile.getOwner().Equals(player));
    }

    [Test]
    public void TestSetOwner()
    {
        Player player = new Player();
        tile.setOwner(player);
        Assert.That(tile.getOwner().Equals(player));
    }

    [Test]
    public void TestRemoveOwner()
    {
        Player owner = new Player();
        tile.setOwner(owner);
        tile.removeOwner();
        Assert.That(tile.owner == null);
    }

    [Test]
    public void TestCheckHotel()
    {
        tile.setNumOfHouse(4);
        tile.pc = propColour.GREEN;
        Assert.IsTrue(tile.checkHotel(propColour.GREEN));

        tile.setNumOfHouse(0);
        tile.pc = propColour.STATION;
        Assert.IsFalse(tile.checkHotel(propColour.STATION));

        tile.setNumOfHouse(0);
        tile.pc = propColour.UTILITIES;
        Assert.IsFalse(tile.checkHotel(propColour.UTILITIES));

        tile.setNumOfHouse(2);
        tile.pc = propColour.BROWN;
        Assert.IsFalse(tile.checkHotel(propColour.BROWN));
    }

    [Test]
    public void TestSetHotes()
    {
        tile.setHotel(true);
        Assert.That(tile.hotel == true);
    }

    [Test]
    public void TestGetNumOfHouses()
    {
        tile.setNumOfHouse(4);
        Assert.That(tile.getNumOfHouse() == 4);
    }

    [Test]
    public void TestSetNumOfHouses()
    {
        tile.setNumOfHouse(2);
        Assert.That(tile.numOfHouse == 2);
    }

    [Test]
    public void TestChangeMortgageStatus()
    {
        tile.changeMortgageStatus();
        Assert.That(tile.mortgaged == true);
        tile.changeMortgageStatus();
        Assert.That(tile.mortgaged == false);
    }

    [Test]
    public void TestGetPC()
    {
        tile.pc = propColour.BLUE;
        Assert.That(tile.getPC() == propColour.BLUE);
    }
}
