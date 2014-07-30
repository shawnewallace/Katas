using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UK
{
	public class UrinalRules
	{
		public static int? Solve(bool[] stalls, bool queued)
		{
			var positions = stalls
					.Select((occupied, index) => new { index, occupied, neighbors = Neighbors(stalls, index) })
					.ToList();
			
			var result = positions
				.Where(x => !x.occupied && (x.neighbors == 0 || (queued || positions.Any(y => y.occupied && y.neighbors == x.neighbors))))
				.OrderBy(x => x.neighbors)
				.ThenByDescending(x => x.index)
				.Select(x => (int?)x.index)
				.FirstOrDefault();

			return result;
		}

		private static int Neighbors(IList<bool> stalls, int index)
		{
			return (index > 0 && stalls[index - 1] ? 1 : 0)
					+ (index + 1 < stalls.Count && stalls[index + 1] ? 1 : 0);
		}
	}


	[TestFixture]
	public class UrinalRulesTests
	{
		[Test]
		public void all_occupied()
		{
			Assert.IsNull(UrinalRules.Solve(new[] { true, true, true, true, true }, false),
				"All stalls are occupied. You should return a null (Stalemate).");
		}

		[Test]
		public void rule_1()
		{
			Assert.AreEqual(4, UrinalRules.Solve(new[] { false, false, false, false, false }, false),
				"Rule 1: Get as far away from the door as possible.");
		}

		[Test]
		public void rule_2()
		{
			Assert.AreEqual(2, UrinalRules.Solve(new[] { true, false, false, false, true }, false), 
			"Rule 2: Avoid standing next to another dude.");
		}

		[Test]
		public void rule_3_e_1()
		{
			Assert.AreEqual(3, UrinalRules.Solve(new[] { true, true, true, false, true }, false), 
			"Rule 3, Exception 1: You can have two neighbors if someone else already does.");
		}

		[Test]
		public void rule_3_e_2()
		{
			Assert.AreEqual(3, UrinalRules.Solve(new[] { true, false, true, false, true }, true), 
			"Rule 3, Exception 1: You can have two neighbors if there is a line.");
		}

		[Test]
		public void rule_3()
		{
			Assert.IsNull(UrinalRules.Solve(new[] { true, false, true, false, true }, false),
			 "Rule 3: Really avoid standing next to TWO other dudes.");
		}

		[Test]
		public void rule_2_e_2()
		{
			Assert.AreEqual(3, UrinalRules.Solve(new[] { true, true, false, false, true }, false), 
			"Rule 2, Exception 2: You can have a neighbor if someone else already does.");
		}

		[Test]
		public void rule_2_e_1()
		{
			Assert.AreEqual(4, UrinalRules.Solve(new[] { false, true, false, true, false }, true), 
			"Rule 2, Exception 1: You can have a neighbor if there is a line.");
		}
	}
}
