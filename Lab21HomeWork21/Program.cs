using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab21HomeWork21
{
    class Program
    {
        private static int[,] pole;
        private static int b;
        private static int a;
        // Классс моделирующий 1 садовника
        private static void Garden1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        // Классс моделирующий 2 садовника
        private static void Garden2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Укажите длину участка в метрах:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите ширину участка в метрах:");
            b = Convert.ToInt32(Console.ReadLine());

            pole = new int[a, b];

            Thread gardener1 = new Thread(Garden1);
            Thread gardener2 = new Thread(Garden2);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();
            // Вывод результата
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }

    }
}
