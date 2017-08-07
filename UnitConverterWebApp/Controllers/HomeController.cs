using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UnitConverterWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Convert(string text, string action)
        {
			if (action == "Yards to meters")
			{
				return YardsToMeters(text);
			}

			return InchesToCentimeters(text);
		}


		public IActionResult YardsToMeters(string input)
        {
			var converter = new UnitConverter();

			var result = "";

			for (int i = 0; i < converter.YardsToMeters(input).Count(); i++)
			{
				result += converter.YardsToMeters(input)[i] + Environment.NewLine;
			}

			return Content(result);
		}

		public IActionResult InchesToCentimeters(string input)
        {
			var converter = new UnitConverter();

			var result = "";

			for (int i = 0; i < converter.YardsToMeters(input).Count(); i++)
			{
				result += converter.InchesToCentimeters(input)[i] + Environment.NewLine;
			}

			return Content(result);
		}
    }
}
