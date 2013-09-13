using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SudokuSolver.lib;
using SudokuSolver.web.Models;

namespace SudokuSolver.web.Controllers
{
	public class HomeController : Controller
	{
		private readonly SudokuSolverCs _service;

		public HomeController()
		{
			_service = new SudokuSolverCs();
		}

		public ActionResult Index()
		{
			var model = new BoardUIModel(_service.get_board(null));

			return View(model);
		}

		[HttpPost]
		public ActionResult Board(string input)
		{
			var model = new BoardUIModel(_service.get_board(input));

			return View("Index", model);
		}

		[HttpPost]
		public ActionResult Solve(string[] values)
		{
			var input = string.Join("", values);
			var model = new BoardUIModel(_service.search(_service.parse_grid(input)));

			return View("Index", model);
		}
	}
}
