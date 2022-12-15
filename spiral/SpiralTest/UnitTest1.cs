namespace SpiralTest;

public class UnitTest1
{
	private const string BLANK = "-";

	// [Fact]
	// public void Test1()
	// {
	// 	var subject = Initialize(new string[2, 2]);
	// 	var expected = new string[2, 2] { { BLANK, BLANK }, { BLANK, BLANK } };

	// 	subject.ShouldBeEquivalentTo(expected);
	// }

	[Fact]
	public void ItMakesASpiralFor2x2()
	{
		var subject = Initialize(new string[2, 2]);
		var expected = new string[2, 2] { { "0", "1" }, { "3", "2" } };
		subject = FillSpiral(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	[Fact]
	public void ItMakesASpiralFor3x3()
	{
		var subject = Initialize(new string[3, 3]);
		var expected = new string[3, 3] {
			{ "0", "1", "2" },
			{ "7", "8", "3" },
			{ "6", "5", "4" } };
		subject = FillSpiral(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	private string[,] FillSpiral(string[,] subject)
	{
		var xUpperBound = subject.GetUpperBound(0);
		var xLowerBound = subject.GetLowerBound(0);
		var yUpperBound = subject.GetUpperBound(1);
		var yLowerBound = subject.GetLowerBound(1);
		var numIterations = subject.Length;

		var xCurrent = 0;
		var yCurrent = 0;

		bool incrementX = true;
		bool incrementY = false;
		bool decrementX = false;
		bool decrementY = false;

		Console.WriteLine($"START: numIterations:{numIterations}");
		for (var i = 0; i < numIterations; i++)
		{
			subject[yCurrent, xCurrent] = i.ToString();
			Console.WriteLine($"x:{xCurrent}, y:{yCurrent}, i:{i}, incrementX:{incrementX}, incrementY:{incrementY}, decrementX:{decrementX}, decrementY:{decrementY}");
			Console.WriteLine($"xmin:{xLowerBound}, xmax:{xUpperBound}, ymin:{yLowerBound}, ymax:{yUpperBound},");
			OutputTheThing(subject);

			if (incrementX)
			{
				xCurrent++;
				if (xCurrent >= xUpperBound)
				{
					xCurrent = xUpperBound;
					xUpperBound--;
					incrementX = false;
					incrementY = true;
					decrementX = false;
					decrementY = false;
				}
				continue;
			}

			if (incrementY)
			{
				yCurrent++;
				if (yCurrent >= yUpperBound)
				{
					yCurrent = yUpperBound;
					yUpperBound--;
					incrementX = false;
					incrementY = false;
					decrementX = true;
					decrementY = false;
				}
				continue;
			}

			if (decrementX)
			{
				xCurrent--;
				if (xCurrent <= xLowerBound)
				{
					xCurrent = xLowerBound;
					xLowerBound++;
					incrementX = false;
					incrementY = false;
					decrementX = false;
					decrementY = true;
				}
				continue;
			}

			if (decrementY)
			{
				yCurrent--;
				if (yCurrent <= yLowerBound)
				{
					yLowerBound++;
					yCurrent = yLowerBound;
					incrementX = true;
					incrementY = false;
					decrementX = false;
					decrementY = false;
				}
				continue;
			}
		}

		return subject;
	}

	private void OutputTheThing(string[,] subject)
	{
		var xUpperBound = subject.GetUpperBound(0);
		var yUpperBound = subject.GetUpperBound(1);

		Console.WriteLine("*****************");
		for (var y = 0; y <= yUpperBound; y++)
		{
			for (var x = 0; x <= xUpperBound; x++)
			{
				Console.Write(subject[y, x]);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
		Console.WriteLine("*****************");
	}

	private string[,] Initialize(string[,] strings)
	{
		var xUpperBound = strings.GetUpperBound(0);
		var yUpperBound = strings.GetUpperBound(1);

		for (var x = 0; x <= xUpperBound; x++)
			for (var y = 0; y <= yUpperBound; y++)
				strings[y, x] = BLANK;

		// OutputTheThing(strings);

		return strings;
	}
}