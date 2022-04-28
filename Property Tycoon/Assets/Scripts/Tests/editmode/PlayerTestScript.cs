using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;



public class PlayerTestScript
{
    
    private Player player;
    private BoardTile tile;

    [SetUp]
    public void SetUp()
    {
        player = new Player();
        tile = new BoardTile();
    }

    [Test]
    public void TestGetBankrupt()
    {
        player.bankrupt = false;
        Assert.IsFalse(player.getBankrupt());

        player.bankrupt = true;
        Assert.IsTrue(player.getBankrupt());
    }

    [Test]
    public void TestAddCash()
    {
        player.cash = 0;
        player.addCash(100);
        Assert.That(player.cash >= 100);

        player.addCash(200);
        Assert.That(player.cash >= 300);
        Assert.That(player.cash != 0);
    }

    [Test]
    public void TestGetCash()
    {
        player.cash = 0;
        player.addCash(500);
        Assert.That(player.getCash() >= 500);
        player.addCash(500);
        Assert.That(player.getCash() >= 500);
    }

    [Test]
    public void TestAddToProperties()
    {
        tile.cost = 500;
        player.cash = 0;
        Assert.IsFalse(player.addToProperties(tile));

        player.cash = tile.cost;
        int cash = player.cash;
        Assert.IsTrue(player.addToProperties(tile));
        Assert.That(player.cash >= (cash - tile.getCost()));
        Assert.That(tile.getOwner() == player);
        Assert.IsFalse(player.addToProperties(tile));

    }

    [Test]
    public void TestAddToMortgagedProperties()
    {
        tile.cost = 500;
        Assert.IsFalse(player.addToMortgagedProperties(tile));

        player.ownedProperties.Add(tile);
        player.mortgagedProperties.Add(tile);
        Assert.IsFalse(player.addToMortgagedProperties(tile));

        player.mortgagedProperties.Remove(tile);
        Assert.IsTrue(player.addToMortgagedProperties(tile));
        Assert.That(player.cash >= (tile.getCost() / 2));

    }

    [Test]
    public void TestRemoveMortgage()
    {
        player.cash = 0;
        tile.cost = 500;
        player.mortgagedProperties.Add(tile);
        Assert.IsFalse(player.removeMortgage(tile));

        player.cash = 500;
        player.mortgagedProperties.Remove(tile);
        Assert.IsFalse(player.removeMortgage(tile));

        player.mortgagedProperties.Add(tile);
        Assert.IsTrue(player.removeMortgage(tile));
        Assert.That(player.cash >= (tile.getCost() / 2));
        Assert.That(tile.getOwner() == player);

    }

    [Test]
    public void TestSellProperty()
    {
        Assert.IsFalse(player.sellProperty(tile));

        player.mortgagedProperties.Add(tile);
        Assert.IsTrue(player.sellProperty(tile));
        Assert.That(tile.getOwner() == null);
        Assert.That(player.cash >= (tile.getCost() / 2));

        player.mortgagedProperties.Remove(tile);
        player.ownedProperties.Add(tile);
        Assert.IsTrue(player.sellProperty(tile));
        Assert.That(tile.getOwner() == null);
        Assert.That(player.cash >= (tile.getCost()));

    }
}
