using System;
using System.Linq;
using UnitConverterWebApp;
using Xunit;

namespace UnitConverterTests
{
    public class UnitConverterTests
    {
		[Theory]
		[InlineData("1", "0.9144")]
		[InlineData("100", "91.44")]
		[InlineData("5", "4.572")]
		[InlineData("17.96", "16.422624")]
		public void YardsToMeters_GivenSingleValue_ReturnsCorrectString(string input, string expected)
		{
			var converter = new UnitConverter();

			Assert.Equal(expected, converter.YardsToMeters(input).Single());
		}

		[InlineData("100;5;1", "91.44;4.572;0.9144")]
		[InlineData("1;2;3;4;5", "0.9144;1.8288;2.7432;3.6576;4.572")]
		public void YardsToMeters_GivenMultipleValues_ReturnsCorrectMultiLineString(string input, string expected)
		{
			input = input.Replace(";", "\n");
			var expectedArray = expected.Split(';');

			var converter = new UnitConverter();

			Assert.Equal(expectedArray, converter.YardsToMeters(input));
		}

		[InlineData("1", "2.54")]
		[InlineData("32", "81.28")]
		[InlineData("87", "220.98")]
		public void InchesToCentimeters_GivenSingleValue_ReturnsCorrectString(string input, string expected)
		{
			var converter = new UnitConverter();

			Assert.Equal(expected, converter.InchesToCentimeters(input).Single());
		}

		[InlineData("1;2;3;4;5", "2.54;5.08;7.62;10.16;12.7")]
		[InlineData("89.2;1.75;1984", "226.568;4.445;5039.36")]
		public void InchesToCentimeters_GivenMultipleValues_ReturnsCorrectMultiLineString(string input, string expected)
		{
			input = input.Replace(";", "\n");
			var expectedArray = expected.Split(';');

			var converter = new UnitConverter();

			Assert.Equal(expectedArray, converter.InchesToCentimeters(input));
		}
	}
}
