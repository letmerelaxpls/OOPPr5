using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPPr5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1 task1 = new Task1();
            //task1.Active();
            //Task2 task2 = new Task2();
            //task2.Active();
            //Task3 task3 = new Task3();
            //task3.Active();
            //Task4
            int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            int[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            MatrixMultiplication matrixMult = new MatrixMultiplication(matrix1, matrix2);
            int[,] result = matrixMult.Multiply();
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write("{0} ", result[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
