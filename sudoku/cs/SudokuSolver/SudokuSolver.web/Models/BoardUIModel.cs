using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using SudokuSolver.lib;

namespace SudokuSolver.web.Models
{
	public class BoardUIModel : Dictionary<string, string>
	{
		public BoardUIModel()
		{
		}

		public BoardUIModel(string grid)
		{
		}
		
		public BoardUIModel(Dictionary<string, string> board)
		{
			foreach (var cell in board)
			{
				Add(cell.Key, cell.Value);
			}
		}

		public string WhichUnit(string cell)
		{
			var row = cell[0];
			var col = cell[1];

			if ("ABC".Contains(row) && "123".Contains(col)) return "A";
			if ("DEF".Contains(row) && "123".Contains(col)) return "B";
			if ("GHI".Contains(row) && "123".Contains(col)) return "C";
			if ("ABC".Contains(row) && "456".Contains(col)) return "D";
			if ("DEF".Contains(row) && "456".Contains(col)) return "E";
			if ("GHI".Contains(row) && "456".Contains(col)) return "F";
			if ("ABC".Contains(row) && "789".Contains(col)) return "G";
			if ("DEF".Contains(row) && "789".Contains(col)) return "H";
			if ("GHI".Contains(row) && "789".Contains(col)) return "I";

			return "";
		}
	}
}