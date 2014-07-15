using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Game
    {
        private List<Int32> myRolls = new List<Int32>();
        private int rollCurrent;
        private int finalScore;
        

        public int GetScore()
        {
            finalScore = 0;
            rollCurrent = 0;
            ComputeAllRollScore();
            return finalScore;
        }

        private void ComputeAllRollScore()
        {

            if(myRolls.Count != 20) 
            {
                if (myRolls.Count == 19)
                {
                    for (int frames = 0; frames < 10; frames++)
                    {
                        if (myRolls[rollCurrent] == 10)
                            ScoreStrike();
                        else if (SumUpRollsFromStart(2) == 10)
                            ScoreSpare();
                        else
                            ScoreNormal();
                    }
                }

                if (myRolls.Distinct().Count() == 1)  //this is for all strike
                {

                    for (int frames = 0; frames < 10; frames++)
                    {
                        if (myRolls[rollCurrent] == 10)
                            ScoreStrike();
                        else if (SumUpRollsFromStart(2) == 10)
                            ScoreSpare();
                        else
                            ScoreNormal();
                    }

                }
                else 
                {
                    for (int frames = 0; frames < (myRolls.Count / 2); frames++)
                    {
                        if (myRolls[rollCurrent] == 10)
                            ScoreStrike();
                        else if (SumUpRollsFromStart(2) == 10)
                            ScoreSpare();
                        else
                            ScoreNormal();
                    }
                }

            }
           
            else
            {
                for (int frames = 0; frames < 10; frames++)
                {
                    if (myRolls[rollCurrent] == 10)
                        ScoreStrike();
                    else if (SumUpRollsFromStart(2) == 10)
                        ScoreSpare();
                    else
                        ScoreNormal();
                }
            }
        }

        private int SumUpRollsFromStart(int noOfRolls)
        {
             int sum = 0;
             for (int i = 0; i < noOfRolls; i++)
             {
                 sum = sum + myRolls[rollCurrent + i];
             }
            return sum;
        }

        private void ScoreNormal()
        {
            finalScore =finalScore+ SumUpRollsFromStart(2);
            rollCurrent =rollCurrent+ 2;
        }

        private void ScoreSpare()
        {
            finalScore =finalScore + SumUpRollsFromStart(3);
            rollCurrent =rollCurrent + 2;
        }

        private void ScoreStrike()
        {
            finalScore =finalScore + SumUpRollsFromStart(3);
            rollCurrent=rollCurrent+1;
        }

        public void Roll(int pins)
        {
            myRolls.Add(pins);
        }
    }
}

