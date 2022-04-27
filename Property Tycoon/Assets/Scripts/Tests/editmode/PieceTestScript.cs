using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


namespace Tests
{
    public class PieceTestScript
    {

        private Piece piece;

        [SetUp]
        public void SetUp()
        {
            piece = new Piece();
        }

        [Test]
        public void TestMoveHelper()
        {
            
        }
       
        [Test]
        public void TestMovePiece()
        {           
            int amount = 4;
            int tt = piece.totalTiles;

            piece.movePiece(amount);

            Assert.That(piece.totalTiles == (tt + amount));
            Assert.That(piece.currentTile == (piece.totalTiles % 40 + 40) % 40);
            Assert.IsTrue(piece.move);
            
        }

        [Test]
        public void TestGetCurrentTile()
        {
            int amount = 10;
            piece.movePiece(amount);

            Assert.That(piece.getCurrentTile() == (piece.totalTiles % 40 + 40) % 40);
        }

        [Test]
        public void TestGetTotalTiles()
        {
            int amount = 5;
            int tt = piece.totalTiles;

            piece.movePiece(amount);

            Assert.That(piece.getTotalTiles() == (tt + amount));
        }
    }
}