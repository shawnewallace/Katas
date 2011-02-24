using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BowlingGameLib.Features
{
    [Binding]
    public class BowlingGameScoringSteps
    {
        private BowlingGame _game;
        private int _score;

        [BeforeScenario()]
        public void Before()
        {
            _game = new BowlingGame();
            _score = 0;
        }

        [Given(@"I make no rolls")]
        public void GivenIMakeNoRolls()
        {
        }

        [Given(@"I make the following rolls:")]
        public void GivenIMakeTheFollowingRolls(Table table)
        {
            foreach(var row in table.Rows)
            {
                _game.Roll(int.Parse(row["roll"]));
            }
        }

				[Given(@"I make the following rolls:(.*)")]
				public void GivenIMakeTheFollowingRolls(string rolls)
				{
					var table = rolls.Trim().Split(',');
					foreach (var row in table)
					{
						_game.Roll(int.Parse(row));
					}
				}

        [When(@"I score it")]
        public void WhenIScoreIt()
        {
            _score = _game.Score();
        }

        [Then(@"My score should be (\d+)")]
        public void ThenMyScoreShouldBe(int score)
        {
            Assert.That(_score == score);
        }

    }
}
