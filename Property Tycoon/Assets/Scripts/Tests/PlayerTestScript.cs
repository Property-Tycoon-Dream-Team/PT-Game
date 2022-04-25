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
    public void TestAddToProperties()
    {

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


}