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
            switch (action)
            {
                case "Yards to meters":
                    return InvokeConversionMethod("YardsToMeters", text);
                case "Miles to kilometers":
                    return InvokeConversionMethod("MilesToKilometers", text);
                default:
                    return InvokeConversionMethod("InchesToCentimeters", text);
            }
        }


        public IActionResult InvokeConversionMethod(string action, string input)
        {
            var converter = new UnitConverter();

            var result = "";
            MethodInfo method = converter.GetType().GetMethod(action);
            method.Invoke(converter, new object[] { input });

            for (int i = 0; i < (method.Invoke(converter, new object[] { input }) as string[]).Count(); i++)
            {
                result += (method.Invoke(converter, new object[] { input }) as string[])[i] + Environment.NewLine;
            }

            return Content(result);
        }
    }
}
