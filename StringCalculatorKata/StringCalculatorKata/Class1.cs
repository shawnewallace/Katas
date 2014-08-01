using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculatorKata
{
	[TestFixture]
	public class StringCalculatorTests
	{
		private StringCalculator _calculator;

		[SetUp]
		public void SetUp()
		{
			_calculator = new StringCalculator();
		}

		[Test]
		public void it_returns_zero_if_passed_empty_string()
		{
			Assert.AreEqual(0, _calculator.Add(""));
		}

		[Test]
		public void it_returns_the_number_if_passed_one_number_in_string()
		{
			Assert.AreEqual(1, _calculator.Add("1"));
		}

		[TestCase("1,2", 3)]
		[TestCase("10,20", 30)]
		[TestCase("5,4", 9)]
		public void it_adds_two_numbers(string numbers, int expected)
		{
			Assert.AreEqual(expected, _calculator.Add(numbers));
		}

		[TestCase("1,2,3", 6)]
		[TestCase("10,20,30", 60)]
		[TestCase("5,4,21", 30)]
		[TestCase("5,4,", 9)]
		public void it_adds_varied_quantities_of_numbers(string numbers, int expected)
		{
			Assert.AreEqual(expected, _calculator.Add(numbers));
		}
	}

	public class StringCalculator
	{
		public int Add(string numbers)
		{
			var numberStringArray = numbers.Split(',');

			return numberStringArray.Sum(n => ((n == "") ? 0 :  Convert.ToInt32(n)));
		}
	}
}
