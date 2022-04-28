using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PiecePlaymodeTestScript
{ 
    [UnityTest]
    public IEnumerator TestMoveHelper()
    {            
        var go = new GameObject();
        var piece = go.AddComponent<Piece>();

        piece.movePiece(4);
        piece.moveHelper();

        yield return new WaitForSecondsRealtime(5);

        Assert.AreEqual(piece.transform.position, go.transform.position);
        Assert.IsFalse(piece.move);
        }
    }
