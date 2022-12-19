namespace SpiralTest;

public class ArrayFiller_SpiralTests
{
	private const string BLANK = "-";
	private readonly ArrayFillerSpiral _objectUnderTest;

	public ArrayFiller_SpiralTests(){
		_objectUnderTest = new ArrayFillerSpiral(BLANK);
	}

	[Fact]
	public void Test1()
	{
		var subject = Initialize(new string[2, 2]);
		var expected = new string[2, 2] {
			{ "0", "1" },
			{ "3", "2" }
		};
		subject = _objectUnderTest.Fill(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	[Fact]
	public void ItMakesASpiralFor2x2()
	{
		var subject = Initialize(new string[2, 2]);
		var expected = new string[2, 2] { { "0", "1" }, { "3", "2" } };
		subject = _objectUnderTest.Fill(subject);

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
		subject = _objectUnderTest.Fill(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	[Fact]
	public void ItMakesASpiralFor4x3()
	{
		var subject = Initialize(new string[4, 3]);
		var expected = new string[4, 3] {
			{ "0", "1", "2" },
			{ "9", "10", "3" },
			{ "8", "11", "4" },
			{ "7", "6", "5" } };
		subject = _objectUnderTest.Fill(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	[Fact]
	public void ItMakesASpiralFor3x4()
	{
		var subject = Initialize(new string[3, 4]);
		var expected = new string[3, 4] {
			{ "0", "1", "2", "3" },
			{ "9", "10", "11", "4" },
			{ "8", "7", "6", "5" } };
		subject = _objectUnderTest.Fill(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	[Fact]
	public void ItMakesASpiralFor4x4()
	{
		var subject = Initialize(new string[4, 4]);
		var expected = new string[4, 4] {
			{ "0", "1", "2", "3" },
			{ "11", "12", "13", "4" },
			{ "10", "15", "14", "5" },
			{ "9", "8", "7", "6" } };
		subject = _objectUnderTest.Fill(subject);

		subject.ShouldBeEquivalentTo(expected);
	}

	private void OutputTheThing(string[,] subject)
	{
		var rows = subject.GetLength(0);
		var cols = subject.GetLength(1);

		Console.WriteLine("*****************");
		for (var row = 0; row < rows; row++)
		{
			for (var col = 0; col < cols; col++)
			{
				Console.Write(subject[row, col]);
				Console.Write(" ");
			}
			Console.WriteLine();
		}
		Console.WriteLine("*****************");
	}

	private string[,] Initialize(string[,] strings)
	{
		int rows = strings.GetLength(0);
		int cols = strings.GetLength(1);

		for (var row = 0; row < rows; row++)
			for (var col = 0; col < cols; col++)
				strings[row, col] = BLANK;

		return strings;
	}
}