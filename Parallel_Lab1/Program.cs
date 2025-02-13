using System.Diagnostics;

namespace Parallel_Lab1;

class Program
{
    static void Main(string[] args)
    {
        int rows = 20000, columns = 30000, k = 13;

        IntMatrix A = new IntMatrix(rows, columns);
        IntMatrix B = new IntMatrix(rows, columns);
        IntMatrix C = new IntMatrix(rows, columns);
        
        A.FillMatrixWithRands();
        B.FillMatrixWithRands();
        
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        C.CalculateC(A, B, k);

        stopwatch.Stop();
        Console.WriteLine($"Rows: {rows}\tColumns: {columns}\nTime elapsed: {stopwatch.ElapsedMilliseconds} ms\n");

        // Console.WriteLine("Matrix A:");
        // A.PrintMatrix();
        //
        // Console.WriteLine("Matrix B:");
        // B.PrintMatrix();
        //
        // Console.WriteLine("Matrix C:");
        // C.PrintMatrix();
    }
}