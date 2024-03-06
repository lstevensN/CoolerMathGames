using CoolerMathGames.Models;
using CoolerMathGames.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoolerMathGames.Controllers
{
	public class HomeController : Controller
	{
		IDataAccessLayer dal;

		public HomeController(IDataAccessLayer indal)
		{
			dal = indal;
		}

		public IActionResult Index()
		{
			return View(dal.GetCollection());
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
