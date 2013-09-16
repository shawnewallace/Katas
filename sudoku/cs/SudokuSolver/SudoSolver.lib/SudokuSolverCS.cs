using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace SudokuSolver.lib
{

	//http://norvig.com/sudoku.html
	//http://aspadvice.com/blogs/rbirkby/attachment/34077.ashx

	public class SudokuSolverCs
	{
		public const string ROWS = "ABCDEFGHI";
		public const string COLS = "123456789";
		private const string DIGITS = COLS;
		private readonly string[] Squares = StringExtensions.cross(ROWS, COLS);
		private Dictionary<string, IEnumerable<string>> Peers;
		private Dictionary<string, IGrouping<string, string[]>> Units;
		
		public SudokuSolverCs()
		{
			var unitlist = (
				(from c in COLS select StringExtensions.cross(ROWS, c.ToString()))
					.Concat(from r in ROWS select StringExtensions.cross(r.ToString(), COLS))
					.Concat(from rs in (new[] { "ABC", "DEF", "GHI" }) from cs in (new[] { "123", "456", "789" }) select StringExtensions.cross(rs, cs))
				);

			Units = (
				from s in Squares
					from u in unitlist where u.Contains(s)
					group u by s into g
						select g).ToDictionary(g => g.Key);

			Peers = (
				from s in Squares
					from u in Units[s]
						from s2 in u where s2 != s
						group s2 by s into g
							select g).ToDictionary(g => g.Key, g => g.Distinct());
		}

		public Dictionary<string, string> print_board(Dictionary<string, string> values)
		{
			if (values == null) return null;

			var width = 1 + (from s in Squares select values[s].Length).Max();
			var line = "\n" + String.Join("+", Enumerable.Repeat(new String('-', width * 3), 3).ToArray());

			foreach (var r in ROWS)
			{
				Console.WriteLine(String.Join("",
						(from c in COLS
						 select values["" + r + c].Center(width) + ("36".Contains(c) ? "|" : "")).ToArray())
								+ ("CF".Contains(r) ? line : ""));
			}

			Console.WriteLine();
			return values;
		}

		public Dictionary<string, string> parse_grid(string grid)
		{
			//var grid2 = from c in grid where "0.-123456789".Contains(c) select c;
			var values = Squares.ToDictionary(s => s, s => DIGITS); //To start, every square can be any digit

			foreach (var sd in ArrayExtensions.zip(Squares, (from s in grid select s.ToString()).ToArray()))
			{
				var s = sd[0];
				var d = sd[1];

				if (DIGITS.Contains(d) && assign(values, s, d) == null)
				{
					return null;
				}
			}
			return values;
		}

		/// <summary>Using depth-first search and propagation, try all possible values.</summary>
		public Dictionary<string, string> search(Dictionary<string, string> values)
		{
			if (values == null)
			{
				return null; // Failed earlier
			}
			if (ArrayExtensions.all(from s in Squares select values[s].Length == 1 ? "" : null))
			{
				return values; // Solved!
			}

			// Chose the unfilled square s with the fewest possibilities
			var s2 = (from s in Squares where values[s].Length > 1 orderby values[s].Length ascending select s).First();

			return ArrayExtensions.some(from d in values[s2]
									select search(assign(new Dictionary<string, string>(values), s2, d.ToString())));
		}

		private Dictionary<string, string> assign(Dictionary<string, string> values, string s, string d)
		{
			if (ArrayExtensions.all(
				from d2 in values[s]
				where d2.ToString() != d
				select eliminate(values, s, d2.ToString())))
			{
				return values;
			}
			return null;
		}

		private Dictionary<string, string> eliminate(Dictionary<string, string> values, string s, string d)
		{
			if (!values[s].Contains(d))
			{
				return values;
			}
			values[s] = values[s].Replace(d, "");
			if (values[s].Length == 0)
			{
				return null; //Contradiction: removed last value
			}
			else if (values[s].Length == 1)
			{
				//If there is only one value (d2) left in square, remove it from peers
				var d2 = values[s];
				if (!ArrayExtensions.all(from s2 in Peers[s] select eliminate(values, s2, d2)))
				{
					return null;
				}
			}

			//Now check the places where d appears in the units of s
			foreach (var u in Units[s])
			{
				var dplaces = from s2 in u where values[s2].Contains(d) select s2;
				if (dplaces.Count() == 0)
				{
					return null;
				}
				else if (dplaces.Count() == 1)
				{
					// d can only be in one place in unit; assign it there
					if (assign(values, dplaces.First(), d) == null)
					{
						return null;
					}
				}
			}
			return values;
		}

		public Dictionary<string, string> get_board(string grid)
		{
			if (string.IsNullOrEmpty(grid)) return Squares.ToDictionary(s => s, s => "");

			var x = ArrayExtensions.zip(Squares, (from s in grid select s.ToString()).ToArray());

			return x.ToDictionary(b => b[0], b => b[1]);
		}
	}
}