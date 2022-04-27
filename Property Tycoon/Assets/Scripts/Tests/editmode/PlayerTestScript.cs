using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;



public class PlayerTestScript
{
    
    [Test]
    public void TestGetBankrupt()
    {
        
        Player player = new Player();

        Assert.IsFalse(player.getBankrupt());
        player.bankrupt = true;
        Assert.IsTrue(player.getBankrupt());
    }

    [Test]
    public void TestAddCash()
    {
        Player player = new Player();

        player.cash = 0;
        player.addCash(100);
        Assert.That(player.cash == 100);

        player.addCash(200);
        Assert.That(player.cash == 300);

        Assert.That(player.cash != 0);
    }

    [Test]
    public void TestAddToProperties()
    {
       
        var player = new Player();
        var bt = new BoardTile();
        player.ownedProperties = new List<BoardTile> { bt };

        Assert.IsFalse(player.addToProperties(bt));

        Assert.IsFalse(player.addToProperties(new BoardTile()));
        
        Assert.IsTrue(player.addToProperties(new BoardTile()));

    }

    [Test]
    public void TestAddToMortgagedProperties()
    {

    }

    [Test]
    public void TestRemoveMortgage()
    {

    }

    [Test]
    public void TestSellProperty()
    {

    }
}
