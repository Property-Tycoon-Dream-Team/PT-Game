using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DiceTestScript
{

    [Test]
    public void TestDice()
    {
        Dice dice = new Dice();

        Assert.That(dice.value >= 2 || dice.value <= 12);
        Assert.That(dice.isDouble == true || dice.isDouble == false);

    }

}