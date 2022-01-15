using System.Collections.Immutable;

namespace TennisGame.Lib
{
    public class Tennis
    {
        private const int LOVE = 0;
        private const int FIFTEEN = 1;
        private const int THIRTY = 2;
        private const int FORTY = 3;

        private int palyerOneScroe = 0;
        private int palyerTwoScroe = 0;

        private ImmutableDictionary<int, string> scoreDictionary = new Dictionary<int, string>
        {
            { LOVE, "love" },
            { FIFTEEN, "fifteen" },
            { THIRTY, "thirty" },
            { FORTY, "forty" }

        }.ToImmutableDictionary();

        public string GetGameResult()
        {
            if (this.OnePlayerHasAtLeastFourPoints() && this.OnePlayerHasLeadTwoOrMorePoints())
            {
                return $"{this.GetLeadingPlayer()} wins";
            }

            if (this.BothPlayerHaveAtLeastThreePoints() && this.PlayersHaveEqualPoints())
            {
                return "deuce";
            }

            if (this.BothPlayerHaveAtLeastThreePoints() && this.OnePlayerHasLeadOnePoints())
            {
                return $"advantage {this.GetLeadingPlayer()}";
            }

            return $"{this.scoreDictionary[this.palyerOneScroe]} - {this.scoreDictionary[this.palyerTwoScroe]}";
        }

        public void PlayerOneWinTheBall()
        {
            this.palyerOneScroe++;
        }

        public void PlayerTwoWinTheBall()
        {
            this.palyerTwoScroe++;
        }

        private bool OnePlayerHasAtLeastFourPoints()
        {
            return this.palyerOneScroe > FORTY || this.palyerTwoScroe > FORTY;
        }

        private bool BothPlayerHaveAtLeastThreePoints()
        {
            return this.palyerOneScroe >= FORTY && this.palyerTwoScroe >= FORTY;
        }

        private bool PlayersHaveEqualPoints()
        {
            return this.palyerOneScroe == this.palyerTwoScroe;
        }

        private bool OnePlayerHasLeadTwoOrMorePoints()
        {
            return this.palyerOneScroe >= this.palyerTwoScroe + 2 || this.palyerTwoScroe >= this.palyerOneScroe + 2;
        }

        private bool OnePlayerHasLeadOnePoints()
        {
            return this.palyerOneScroe == this.palyerTwoScroe + 1 || this.palyerTwoScroe == this.palyerOneScroe + 1;
        }

        private string GetLeadingPlayer()
        {
            return this.palyerOneScroe > this.palyerTwoScroe ? "Player1" : "Player2";
        }
    }
}