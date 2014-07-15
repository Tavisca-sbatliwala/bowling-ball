using System;
using Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingFixtures
{
    [TestClass]
    public class GameFixture
    {
        private Game myGame=new Game();

        private void RollwithSamePin(int numberOfChances, int pins)
        {
            for (int i =0; i < numberOfChances; i++)
            {
                myGame.Roll(pins);
            }
        }

        [TestMethod]
        public void AllGutterBalls() //all gutterball then score is zero
        {
            RollwithSamePin(20, 0);
            int score = myGame.GetScore();
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void AllBallDropOne()
        {
            RollwithSamePin(20, 1);
            int score = myGame.GetScore();
            Assert.AreEqual(20, score);
        }

        [TestMethod]
        public void AllStrike()
        {
            RollwithSamePin(12, 10);        
            int score = myGame.GetScore();
            Assert.AreEqual(300, score);
        }

        [TestMethod]
        public void FirstFrameSpareThenAllOnes()
        {
            RollwithSamePin(2, 5);
            RollwithSamePin(18, 1);
            int score = myGame.GetScore();
            Assert.AreEqual(29, score);
        }

        [TestMethod]
        public void AllFrameSpare()
        {
            RollwithSamePin(21, 5);
            int score = myGame.GetScore();
            Assert.AreEqual(150, score);
        }

        //testcase random
        [TestMethod]
        public void TestRandom1()
        {
            myGame.Roll(2);
            myGame.Roll(3);
            myGame.Roll(8);
            myGame.Roll(1);
            myGame.Roll(7);
            myGame.Roll(2);
            myGame.Roll(1);
            myGame.Roll(2);
            myGame.Roll(4);
            myGame.Roll(5);
            myGame.Roll(7);
            myGame.Roll(1);
            myGame.Roll(3);
            myGame.Roll(4);
            myGame.Roll(7);
            myGame.Roll(2);
            myGame.Roll(9);
            myGame.Roll(0);
            int score = myGame.GetScore();
            Assert.AreEqual(68, score);

        }


    }
}
