using System;
using System.Collections.Generic;

namespace SudokuSolver.lib
{
	public static class ArrayExtensions
	{
		public static IEnumerable<string[]> zip(IList<string> a, IList<string> b)
		{
			var n = Math.Min(a.Count, b.Count);
			var sd = new string[n][];
			for (var i = 0; i < n; i++)
			{
				sd[i] = new string[] { a[i], b[i] };
			}
			return sd;
		}

		public static bool all<T>(IEnumerable<T> seq)
		{
			foreach (var e in seq)
			{
				if (e == null) return false;
			}
			return true;
		}

		public static T some<T>(IEnumerable<T> seq)
		{
			foreach (var e in seq)
			{
				if (e != null) return e;
			}
			return default(T);
		}
	}
}