namespace SpiralTest;

public class ArrayFillerSpiral
{
	internal enum Directions
	{
		right = 0,
		down = 1,
		left = 2,
		up = 3
	}

	private string _blankCellIndicator;

	public ArrayFillerSpiral(string blankCell)
	{
		_blankCellIndicator = blankCell;
	}

	public string[,] Fill(string[,] subject)
	{
		int rows = subject.GetLength(0);
		int cols = subject.GetLength(1);
		int row = 0;
		int col = 0;
		var direction = Directions.right;
		int counter = 0;

		while (counter < (rows * cols))
		{
			subject[row, col] = counter.ToString();
			counter++;

			if (direction == Directions.right)
			{
				col++;
				if (col >= cols || subject[row, col] != _blankCellIndicator)
				{
					col--;
					row++;
					direction = Directions.down;
				}
				continue;
			}

			if (direction == Directions.down)  // moving down
			{
				row++;
				if (row >= rows || subject[row, col] != _blankCellIndicator)  // check if we reached the last row or if the element is already filled
				{
					row--;  // move back to the last element
					col--;  // change direction to left
					direction = Directions.left;
				}
				continue;
			}

			if (direction == Directions.left)  // moving left
			{
				col--;
				if (col < 0 || subject[row, col] != _blankCellIndicator)  // check if we reached the first column or if the element is already filled
				{
					col++;  // move back to the last element
					row--;  // change direction to up
					direction = Directions.up;
				}
				continue;
			}

			if (direction == Directions.up)  // moving up
			{
				row--;
				if (row < 0 || subject[row, col] != _blankCellIndicator)  // check if we reached the first row or if the element is already filled
				{
					row++;  // move back to the last element
					col++;  // change direction to right
					direction = Directions.right;
				}
				continue;
			}
		}

		return subject;
	}

}
