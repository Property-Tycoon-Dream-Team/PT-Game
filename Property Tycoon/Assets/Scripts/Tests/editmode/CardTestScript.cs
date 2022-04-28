using NUnit.Framework;

public class CardTestScript
{
    private Player p1;
    private Player p2;
    private Card card;

    [SetUp]
    public void SetUp()
    {
        p1 = new Player();
        p2 = new Player();
        card = new Card();
    }

    [Test]
    public void TestAction()
    {
        p1.addCash(1000);
        int FP = 0;
        card.amount = 100;
        card.freepark = true;
        card.completeAction(p1, p2);
        Assert.AreEqual(p1.getCash(), (p1.getCash() - card.amount));
        Assert.AreEqual((FP + card.amount), card.manager.freeParkingValue);
    }
}
