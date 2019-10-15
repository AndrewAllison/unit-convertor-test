using System.Globalization;
using System.Linq;

namespace UnitConverterWebApp
{
  public class UnitConverter
  {
    public string[] YardsToMeters(string yards)
    {
      return ConvertStringsByRatio(yards, 0.9144);
    }

    public string[] InchesToCentimeters(string inches)
    {
      return ConvertStringsByRatio(inches, 2.54);
    }

    public string[] MilesToKilometers(string miles)
    {
      return ConvertStringsByRatio(miles, 1.609344);
    }

    private string[] ConvertStringsByRatio(string units, double ratio)
    {
      if (string.IsNullOrWhiteSpace(units))
        return new string[] { "" };

      var inputArray = units.Contains('\n') ? units.Split('\n') : new string[] { units };

      double[] doubles = new double[inputArray.Count()];
      string[] strings = new string[doubles.Length];

      for (int i = 0; i < inputArray.Count(); i++)
      {
        try
        {          
          double value = string.IsNullOrWhiteSpace(inputArray[i]) ? 0 : double.Parse(inputArray[i]);
          doubles[i] = value;
          strings[i] = string.Format("{0}", doubles[i] * ratio);
        }
        catch
        {
          strings[i] = "Not A Number";
        }
      }

      return strings;

    }
  }

}
