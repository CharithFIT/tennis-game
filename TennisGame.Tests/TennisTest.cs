using NUnit.Framework;
using TennisGame.Lib;

namespace TennisGame.Tests
{
    public class TennisTests
    {
        [Test]
        public void Should_Win_Player_Who_Has_At_Least_Four_Points_Total_And_At_Least_Two_Points_More_Than_The_Opponent()
        {
            this.TestGame(4, 6, "Player2 wins");
            this.TestGame(6, 4, "Player1 wins");
            this.TestGame(1, 4, "Player2 wins");
            this.TestGame(2, 4, "Player2 wins");
            this.TestGame(4, 1, "Player1 wins");
            this.TestGame(4, 2, "Player1 wins");
        }

        [Test]
        public void Should_Game_Deduce_When_Playes_Have_More_Than_Three_Points_And_Score_Are_Equal()
        {
            this.TestGame(3, 3, "deuce");
            this.TestGame(4, 4, "deuce");
            this.TestGame(5, 5, "deuce");
        }

        [Test]
        public void Should_Game_Advantage_When_Playes_Have_More_Than_Three_Points_And_Leading_Player_score_A_One_point_Than_Other()
        {
            this.TestGame(4, 3, "advantage Player1");
            this.TestGame(3, 4, "advantage Player2");
            this.TestGame(5, 4, "advantage Player1");
            this.TestGame(3, 4, "advantage Player2");
        }

        [Test]
        public void Should_Score_Correclty()
        {
            this.TestGame(0, 0, "love - love");
            this.TestGame(1, 0, "fifteen - love");
            this.TestGame(0, 1, "love - fifteen");
            this.TestGame(1, 1, "fifteen - fifteen");
            this.TestGame(2, 0, "thirty - love");
            this.TestGame(2, 1, "thirty - fifteen");
            this.TestGame(2, 2, "thirty - thirty");
            this.TestGame(1, 2, "fifteen - thirty");
            this.TestGame(0, 2, "love - thirty");
            this.TestGame(3, 0, "forty - love");
            this.TestGame(3, 1, "forty - fifteen");
            this.TestGame(3, 2, "forty - thirty");
            this.TestGame(3, 3, "deuce");
            this.TestGame(2, 3, "thirty - forty");
            this.TestGame(1, 3, "fifteen - forty");
            this.TestGame(0, 3, "love - forty");
        }

        private void TestGame(int playerOneScore, int playerTwoScore, string expectedResult)
        {
            Tennis tennis = new Tennis();

            for (int i = 0; i < playerOneScore; i++)
            {
                tennis.PlayerOneWinTheBall();
            }

            for (int i = 0; i < playerTwoScore; i++)
            {
                tennis.PlayerTwoWinTheBall();
            }

            Assert.AreEqual(expectedResult, tennis.GetGameResult());
        }
    }
}