using System;
using System.Linq;
using System.Reflection;
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

      var converter = new UnitConverter();

      var result = "";
      string[] resultsArray;

      switch (action)
      {
        case "Yards to meters":
          resultsArray = converter.YardsToMeters(text);
          break;
        case "Miles to kilometers":
          resultsArray = converter.MilesToKilometers(text);
          break;
        default:
          resultsArray = converter.InchesToCentimeters(text);
          break;
      }

      result = string.Join(Environment.NewLine, resultsArray);

      return Content(result);
    }
  }
}
