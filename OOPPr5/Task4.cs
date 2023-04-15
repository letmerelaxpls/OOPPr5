using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPPr5
{
    class MatrixMultiplication
    {
        private int[,] matrix1;
        private int[,] matrix2;
        private int[,] result;
        private Semaphore semaphore;
        private int activeThreads = 0;
        private object objectLock = new object();

        public MatrixMultiplication(int[,] matrix1, int[,] matrix2)
        {
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
            result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
            semaphore = new Semaphore(Environment.ProcessorCount, Environment.ProcessorCount);
        }
        public int[,] Multiply()
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.GetLength(1); j++)
                {
                    semaphore.WaitOne();
                    Interlocked.Increment(ref activeThreads);
                    ThreadPool.QueueUserWorkItem(new WaitCallback(Calculate), new int[] { i, j });
                }
            }

            while (activeThreads > 0)
            {
                Thread.Sleep(100);
            }

            return result;
        }
        private void Calculate(object args)
        {
            int[] indexes = (int[])args;
            int i = indexes[0];
            int j = indexes[1];

            int sum = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                sum += matrix1[i, k] * matrix2[k, j];
            }

            lock (objectLock)
            {
                result[i, j] = sum;
            }

            semaphore.Release();
            Interlocked.Decrement(ref activeThreads);
        }
    }
}
