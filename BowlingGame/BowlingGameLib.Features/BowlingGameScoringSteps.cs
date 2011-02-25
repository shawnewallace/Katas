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
		
		[Given(@"A new game")]
		public void ANewGame()
		{
			_game = new BowlingGame();
		}
		
		[When(@"I make the following rolls:(.*)")]
		public void GivenIMakeTheFollowingRolls(string rolls)
		{
			var table = rolls.Trim().Split(',');
			foreach (var row in table)
			{
				_game.Roll(int.Parse(row));
			}
		}

		[Then(@"My score should be (\d+)")]
		public void ThenMyScoreShouldBe(int score)
		{
			Assert.That(_game.Score() == score);
		}

	}
}
