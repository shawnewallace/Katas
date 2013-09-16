using System;
using System.Linq;

namespace SudokuSolver.lib
{
	public static class StringExtensions
	{
		public static string[] cross(string A, string B)
		{
			return (from a in A from b in B select "" + a + b).ToArray();
		}

		public static string Center(this string s, int width)
		{
			var n = width - s.Length;
			if (n <= 0) return s;
			var half = n / 2;

			if (n % 2 > 0 && width % 2 > 0) half++;

			return new string(' ', half) + s + new String(' ', n - half);
		}
	}
}