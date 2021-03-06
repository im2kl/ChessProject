﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class ChessBoardTest
	{
		private ChessBoard chessBoard;
        private Pawn pawn;

        [TestInitialize]
		public void SetUp()
		{
			chessBoard = new ChessBoard();
            pawn = new Pawn();
		}

        [TestMethod]
		public void Has_MaxBoardWidth_of_8()
		{
			Assert.AreEqual(ChessBoard.MaxBoardWidth, 7);
		}

        [TestMethod]
		public void Has_MaxBoardHeight_of_8()
		{
			Assert.AreEqual(ChessBoard.MaxBoardHeight, 7);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(0, 0);
			Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(5, 5);
            Assert.IsTrue(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(11, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(0, 9);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(11, 0);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_X_Values()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(-1, 5);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void IsLegalBoardPosition_False_For_Negative_Y_Values()
		{
			var isValidPosition = pawn.IsLegalBoardPosition(5, -1);
            Assert.IsFalse(isValidPosition);
		}

        [TestMethod]
		public void Avoids_Duplicate_Positioning()
		{
			Pawn firstPawn = new Pawn();
			Pawn secondPawn = new Pawn();
			pawn.Add(firstPawn, 6, 3, PieceColor.Black);
			pawn.Add(secondPawn, 6, 3, PieceColor.Black);
			Assert.AreEqual(firstPawn.XCoordinate, 6);
            Assert.AreEqual(firstPawn.YCoordinate, 3);
            Assert.AreEqual(secondPawn.XCoordinate, -1);
            Assert.AreEqual(secondPawn.YCoordinate, -1);
		}

        [TestMethod]
		public void Limits_The_Number_Of_Pawns()
		{
			for (int i = 0; i < 10; i++)
			{
				Pawn pawn = new Pawn();
				int row = i / ChessBoard.MaxBoardWidth;
				pawn.Add(pawn, 6 + row, i % ChessBoard.MaxBoardWidth, PieceColor.Black);
				if (row < 1)
				{
					Assert.AreEqual(pawn.XCoordinate, (6 + row));
					Assert.AreEqual(pawn.YCoordinate, (i % ChessBoard.MaxBoardWidth));
				}
				else
				{
					Assert.AreEqual(pawn.XCoordinate, -1);
                    Assert.AreEqual(pawn.YCoordinate, -1);
				}
			}
		}
	}
}
