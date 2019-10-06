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

        public string[] InchesToCentimeters(string yards)
        {
            return ConvertStringsByRatio(yards, 2.54);
        }

        public string[] MilesToKilometers(string miles)
        {
            return ConvertStringsByRatio(miles, 1.609344);
        }

        private string[] ConvertStringsByRatio(string units, double ratio)
        {
            if (string.IsNullOrWhiteSpace(units))
            {
                return new string[] { "" };
            }

            if (!units.Contains('\n'))
            {
                double d = double.Parse(units, CultureInfo.InvariantCulture) * ratio;

                string[] array = new string[1];
                array[0] = d.ToString();

                return array;
            }
            else
            {
                double[] doubles = new double[units.Split('\n').Count()];

                for (int i = 0; i < units.Split('\n').Count(); i++)
                {
                    double value = double.Parse(units.Split('\n')[i]);
                    doubles[i] = value;

                    string.Format("{0}", value * ratio);
                }

                string[] strings = new string[doubles.Length];

                for (int i = 0; i < units.Split('\n').Length; i++)
                {
                    strings[i] = string.Format("{0}", doubles[i] * ratio);
                }

                return strings;
            }
        }
    }

}
