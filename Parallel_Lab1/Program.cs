using System.Diagnostics;

namespace Parallel_Lab1;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        int rows = 20000, columns = 30000, k = 13, threadsAmount = 96;

        IntMatrix A = new IntMatrix(rows, columns);
        IntMatrix B = new IntMatrix(rows, columns);
        IntMatrix C = new IntMatrix(rows, columns);
        
        stopwatch.Start();
        A.FillWithRandsParallel(threadsAmount);
        B.FillWithRandsParallel(threadsAmount);
        stopwatch.Stop();

        long fillTime = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        
        stopwatch.Start();
        C.CalculateCParallel(A, B, k, threadsAmount);
        stopwatch.Stop();

        long calculationTime = stopwatch.ElapsedMilliseconds;
        
        Console.WriteLine($"Rows: {rows}\tColumns: {columns}\tThreads: {threadsAmount}");
        Console.WriteLine($"Time elapsed to fill matrices with rands: {fillTime} ms");
        Console.WriteLine($"Time elapsed to calculate C matrix: {calculationTime} ms");
        Console.WriteLine($"Total time: {fillTime + calculationTime} ms");

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