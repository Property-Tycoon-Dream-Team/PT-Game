using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BoardTestScript
{
   
    [Test]
    public void TestGetColouredProperties()
    {
        
    }

    [Test]
    public void TestfindTile()
    {

        GameObject go = new GameObject();
        BoardTile tile = go.AddComponent<BoardTile>();  

        Board.boardSquares[10] = tile;  

        Assert.That(Board.findTile(10) == Board.boardSquares[10]);
    }
}
