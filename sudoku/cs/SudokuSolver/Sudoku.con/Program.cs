using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SudokuSolver.lib;
using System.Linq;

namespace Sudoku.con
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = new SodukuGame("4.....8.5.3..........7......2.....6.....8.4......1.......6.3.7.5..2.....1.4......");
			
			Console.ReadLine();
		}

		

		private static void WriteArray(IEnumerable<string> array)
		{
			foreach (var item in array)
			{
				Console.Write(item);
			}
			Console.WriteLine();
		}
	}
}
