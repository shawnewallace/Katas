using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace BowlingGameLib.Tests.Unit
{
    [TestFixture]
    public class Score
    {
        private BowlingGame _game;

        private void DoRolls(int[] rolls)
        {
            foreach (var roll in rolls)
            {
                _game.Roll(roll);
            }
        }

        [SetUp]
        public void SetUp()
        {
            _game = new BowlingGame();
        }

        [Test]
        public void with_zero_rolls()
        {
            Assert.That(_game.Score() == 0);
        }

        [Test]
        public void with_one_roll()
        {
            _game.Roll(9);
            Assert.That(_game.Score() == 9);
        }

        [Test]
        public void with_two_rolls()
        {
            DoRolls(new int[]{3, 6});

            Assert.That(_game.Score() == 9);
        }

        [Test]
        public void with_no_spares_or_strikes()
        {
            DoRolls(new int[]{1,4,4,5});

            Assert.That(_game.Score() == 14);
        }

        [Test]
        public void with_spares_and_strikes()
        {
            DoRolls(new int[] { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 });

            Assert.That(_game.Score() == 133);
        }

        [Test]
        public void perfect_game()
        {
            DoRolls(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 });

            Assert.That(_game.Score() == 300);
        }
    }
}
