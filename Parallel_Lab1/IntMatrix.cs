namespace Parallel_Lab1;

public class IntMatrix
{
    private List<List<int>> matrix;
    private int _rows;
    private int _columns;

    public IntMatrix(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        
        matrix = new List<List<int>>(rows);
        for (int i = 0; i < rows; i++)
        {
            matrix.Add(new List<int>(new int[columns]));
        }
    }

    public void FillMatrixWithRands()
    {
        Random rand = new Random();
        
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                matrix[i][j] = rand.Next(1, 1001);
            }
        }
    }

    public void PrintMatrix()
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                Console.Write(matrix[i][j] + "\t");
            }
            
            Console.WriteLine();
        }
        
        Console.WriteLine();
    }

    public void CalculateC(IntMatrix A, IntMatrix B, int k)
    {
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                matrix[i][j] = A.matrix[i][j] - k * B.matrix[i][j];
            }
        }
    }
}