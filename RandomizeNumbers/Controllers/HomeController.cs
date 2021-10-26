using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomizeNumbers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RandomizeNumbers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GenerateNumbers()
        {
            List<int> listOfInt = GetShuffledListYates(10000);         

            return View("Index", listOfInt);
        }

        public static List<int> GetShuffledListYates(int n)
        {
            Random random = new Random();
            List<int> listOfInt = Enumerable.Range(1, n).ToList();

            int count = listOfInt.Count;

            for (int i = 0; i < count - 1; i++)
            {
                int index = i + random.Next(count - i);
                int temp = listOfInt[index];

                listOfInt[i] = temp;
                listOfInt[index] = listOfInt[i];
            }

            return listOfInt;
        }

    }
}
