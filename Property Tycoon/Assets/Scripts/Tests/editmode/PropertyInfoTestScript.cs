using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PropertyInfoTestScript
{

    private PropertyInfo info;

    [SetUp]
    public void SetUp()
    {
        info = new PropertyInfo();
    }

    [Test]
    public void TestCheckHotel()
    {
        info.setNumOfHouse(4);
        info.pc = propColour.GREEN;
        Assert.IsTrue(info.checkHotel(propColour.GREEN));

        info.setNumOfHouse(0);
        info.pc = propColour.STATION;
        Assert.IsFalse(info.checkHotel(propColour.STATION));

        info.setNumOfHouse(0);
        info.pc = propColour.UTILITIES;
        Assert.IsFalse(info.checkHotel(propColour.UTILITIES));

        info.setNumOfHouse(2);
        info.pc = propColour.BROWN;
        Assert.IsFalse(info.checkHotel(propColour.BROWN));
    }

    [Test]
    public void TestSetHotes()
    {
        info.setHotel(true);

        Assert.That(info.hotel == true);
    }


    [Test]
    public void TestCheckUtility()
    {
        Assert.That(info.checkUtility(propColour.UTILITIES) == true);
        Assert.That(info.checkUtility(propColour.DEEPBLUE) == false);
    }


    [Test]
    public void TestCheckStation()
    {
        Assert.That(info.checkStation(propColour.STATION) == true);
        Assert.That(info.checkStation(propColour.DEEPBLUE) == false);
    }

    [Test]
    public void TestGetOwner()
    {
        Player player = new Player();
        info.setOwner(player);
        Assert.That(info.getOwner().Equals(player));
    }

    [Test]
    public void TestSetOwner()
    {
        Player player = new Player();
        info.setOwner(player);
        Assert.That(info.getOwner().Equals(player));
    }

    [Test]
    public void TestRemoveOwner()
    {
        Player owner = new Player();
        info.setOwner(owner);
        info.removeOwner();
        Assert.That(info.owner == null);
    }

    [Test]
    public void TestGetCost()
    {
        info.cost = 0;
        Assert.That(info.cost == 0);
        info.cost = 500;
        Assert.That(info.cost == 500);
        info.cost = 1000;
        Assert.That(info.cost == 1000);
    }

    [Test]
    public void TestGetNumOfHouses()
    {
        info.setNumOfHouse(4);

        Assert.That(info.getNumOfHouse() == 4);
    }

    [Test]
    public void TestSetNumOfHouses()
    {
        info.setNumOfHouse(2);

        Assert.That(info.numOfHouse == 2);
    }

    [Test]
    public void TestMortgage()
    {
        info.mortgage();

        Assert.That(info.morgaged == true);
    }

    [Test]
    public void TestUnmortgage()
    {
        info.unmortgage();

        Assert.That(info.morgaged == false);
    }

    [Test]
    public void TestGetPC()
    {
        info.pc = propColour.BLUE;

        Assert.That(info.getPC() == propColour.BLUE);
    }
}
