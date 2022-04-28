using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class SystemsMsgsTestScript
{
    private SystemMsgs msg;
    private Text text;

    [SetUp]
    public void SetUp()
    {
        msg = new SystemMsgs();
    }

    [Test]
    public void TestNewMessage()
    {
        string message = "Testing Message";

        msg.NewMessage(message);
    }
}
