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

    public void FillWithRandsParallel(int threadsAmount)
    {
        ThreadLocal<Random> rand = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
        
        // Divide the rows
        int rowsPerThread = _rows / threadsAmount;
        Thread[] threads = new Thread[threadsAmount];
        
        // Start threads
        for (int t = 0; t < threadsAmount; t++)
        {
            int start = rowsPerThread * t;
            int finish = (t == threadsAmount - 1) ? _rows : start + rowsPerThread;
            
            threads[t] = new Thread(() =>
            {
                var rnd = rand.Value;
                for (int i = start; i < finish; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        matrix[i][j] = rnd.Next(1, 1001);
                    }
                }
            });

            threads[t].Start();
        }
        
        // Wait for threads
        foreach (var thread in threads)
        {
            thread.Join();
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
    
    public void CalculateCParallel(IntMatrix A, IntMatrix B, int k, int threadsAmount)
    {
        // Divide the rows
        int rowsPerThread = _rows / threadsAmount;
        Thread[] threads = new Thread[threadsAmount];
        
        // Start threads
        for (int t = 0; t < threadsAmount; t++)
        {
            int start = rowsPerThread * t;
            int finish = (t == threadsAmount - 1) ? _rows : start + rowsPerThread;
            
            threads[t] = new Thread(() =>
            {
                for (int i = start; i < finish; i++)
                {
                    for (int j = 0; j < _columns; j++)
                    {
                        matrix[i][j] = A.matrix[i][j] - k * B.matrix[i][j];
                    }
                }
            });

            threads[t].Start();
        }
        
        // Wait for threads
        foreach (var thread in threads)
        {
            thread.Join();
        }
    }
}