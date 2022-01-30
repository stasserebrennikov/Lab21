using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21
{
    internal class Program
    {
        private static int[,] pole;
        private static int m;
        private static int n;
        static void Main(string[] args)
        {
            Console.WriteLine("Длина сада, n");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ширина сада,m");
            m = Convert.ToInt32(Console.ReadLine());

            pole = new int[n, m];

            Thread sadov1 = new Thread(sad1);
            Thread sadov2 = new Thread(sad2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void sad1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = m - 1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
