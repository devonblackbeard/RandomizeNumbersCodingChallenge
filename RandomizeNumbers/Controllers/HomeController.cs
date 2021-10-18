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
            Random rand = new Random();
            List<int> listOfInt = Enumerable.Range(1, 10000).ToList();

            int count = listOfInt.Count;

            for (int i = 0; i < count; i++)
            {
                int index = i + rand.Next(count - i);
                int temp = listOfInt[index];
                //perform swap
                listOfInt[index] = listOfInt[i];
                listOfInt[i] = temp;
            }

            if (listOfInt.Count != listOfInt.Distinct().Count())
            {
                throw new Exception();
            }

            return View("Index", listOfInt);
        }

    }
}
