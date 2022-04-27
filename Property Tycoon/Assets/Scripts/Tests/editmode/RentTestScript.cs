using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RentTestScript
{
    [Test]
    public void TestGetRent()
    {
        Assert.AreEqual(Rent.getRent(0, 0), 0);
        
        Assert.AreEqual(Rent.getRent(1, 3), 90);
        
        Assert.AreEqual(Rent.getRent(2, 0), 0);
        
        Assert.AreEqual(Rent.getRent(3, 0), 4);
        
        Assert.AreEqual(Rent.getRent(4, 0), 0);
        
        Assert.AreEqual(Rent.getRent(5, 3), 200);
        
        Assert.AreEqual(Rent.getRent(6, 3), 270);
        
        Assert.AreEqual(Rent.getRent(7, 0), 0);
        
        Assert.AreEqual(Rent.getRent(8, 2), 90);
        
        Assert.AreEqual(Rent.getRent(9, 0), 8);
        
        Assert.AreEqual(Rent.getRent(10, 0), 0);
        
        Assert.AreEqual(Rent.getRent(11, 0), 10);

        Assert.AreEqual(Rent.getRent(12, 0), 0);

        Assert.AreEqual(Rent.getRent(13, 1), 50);

        Assert.AreEqual(Rent.getRent(14, 0), 12);

        Assert.AreEqual(Rent.getRent(15, 3), 200);

        Assert.AreEqual(Rent.getRent(16, 4), 750);

        Assert.AreEqual(Rent.getRent(17, 0), 0);

        Assert.AreEqual(Rent.getRent(18, 5), 950);

        Assert.AreEqual(Rent.getRent(19, 1), 80);

        Assert.AreEqual(Rent.getRent(20, 0), 0);

        Assert.AreEqual(Rent.getRent(21, 0), 18);
    }

}
