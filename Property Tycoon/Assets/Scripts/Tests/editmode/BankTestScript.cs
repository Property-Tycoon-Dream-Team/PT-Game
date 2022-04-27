using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

static public class BankTestScript
{
    [Test]
    public static void TestMoney()
    {
        Assert.That(Bank.Money == 50000);
    }
}
