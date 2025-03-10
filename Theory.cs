using System;

namespace lab5
{
    internal class Program
    {

        delegate double[] Work(double[] a);

        static double[] nechet(double[] a)
        {
            Array.Sort(a);
            Array.Reverse(a);
            return a;
        }
        static double[] chet(double[] a)
        {
            Array.Sort(a);
            return a;
        }
        static double[] lesss(double[] a)
        {
            for (int i = a.Length - 1; i >= 0; i -= 2)
            {
                double temp = a[i];
                a[i] = a[i - 1];
                a[i - 1] = temp;
            }
            return a;
        }
        static double[] moreee(double[] a)
        {
            for (int i = 0; i < a.Length; i += 2)
            {
                double temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
            }
            return a;
        }
        static void Main(string[] args)
        {
            task2_23();
            static void print(double[,] a, int n, int m)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(a[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }
            static int solution1_1(int n)
            {
                int f = 1;
                for (int i = 2; i <= n; i++)
                {
                    f *= i;
                }
                return f;
            }
            static void task1_1()
            {
                int s = solution1_1(8) / (solution1_1(5) * solution1_1(8-5));
                int s1 = solution1_1(10) / (solution1_1(5) * solution1_1(10 - 5));
                int s2 = solution1_1(11) / (solution1_1(5) * solution1_1(11 - 5));
                Console.WriteLine(s);
                Console.WriteLine(s1);
                Console.WriteLine(s2);
            }
            static double solution1_2(double a, double b, double c)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            static void task1_2()
            {
                double a1 = 3, b1 = 4, c1 = 5;
                double a2 = 6, b2 = 7, c2 = 8;
                if (a1 + b1 > c1 && a1 + c1 > b1 && b1 + c1 > a1)
                {
                    if (a2 + b2 > c2 && a2 + c2 > b2 && b2 + c2 > a2)
                    {
                        double square1 = solution1_2(a1, b1, c1);
                        double square2 = solution1_2(a2, b2, c2);
                        if (square1 > square2)
                            Console.WriteLine($"The first triangle has bigger square {square1}");
                        else
                            Console.WriteLine($"The second triangle has bigger square {square2}");
                    }
                    else
                    {
                        Console.WriteLine("There is no such triangle");
                    }
                }
                else
                {
                    Console.WriteLine("There is no such triangle");
                }
            }
            static int[] sol2_6(int[] a, int index)
            {
                for (int i = a.Length - 1; i >= index; i--)
                {
                    a[i] = a[i - 1];
                }
                Array.Resize(ref a, a.Length - 1);
                return a;
            }
            static void task2_6()
            {
                int[] a = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
                int[] b = new int[8] { 8, 9, 10, 11, 12, 13, 14, 15 };
                int max1 = 0, index1 = 0;
                int max2 = 0, index2 = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] > max1)
                    {
                        max1 = a[i];
                        index1 = i;
                    }
                }
                a = sol2_6(a, index1);
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] > max2)
                    {
                        max2 = b[i];
                        index2 = i;
                    }
                }
                int p = 0;
                b = sol2_6(b, index2);
                Array.Resize(ref a, a.Length + b.Length);
                for (int i = a.Length - b.Length; i < a.Length; i++)
                {
                    a[i] = b[p];
                    p++;
                }
                foreach (int i in a)
                    Console.WriteLine(i);
            }
            static double[,] sol2_10(double[,] a, int index)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (index != a.GetLength(1) - 1)
                    {
                        for (int j = index; j < a.GetLength(1) - 1; j++)
                        {
                            a[i, j] = a[i, j + 1];
                        }
                    }
                    else break;
                }
                double[,] b = new double[a.GetLength(0), a.GetLength(1) - 1];
                for (int i = 0; i < b.GetLength(0); i++)
                    for (int j = 0; j < b.GetLength(1); j++)
                        b[i, j] = a[i, j];
                return b;
            }
            static void task2_10()
            {
                double[,] a = new double[4, 4] {{1,2,3,4},
                                         {4,5,6,7},
                                         {5,6,7,8},
                                         {6,7,8,9}};
                double max = -100000;
                int indexj1 = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        if (a[i, j] > max)
                        {
                            max = a[i, j];
                            indexj1 = j;
                        }
                    }
                }
                double min = 100000;
                int indexj2 = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = a.GetLength(1) - 1; j > i; j--)
                    {
                        if (a[i, j] < min)
                        {
                            min = a[i, j];
                            indexj2 = j;
                        }
                    }
                }
                a = sol2_10(a, indexj1);
                if (indexj1 != indexj2)
                {
                    a = sol2_10(a, indexj2);
                }
                print(a, a.GetLength(0), a.GetLength(1));
            }
            static double[] sol2_23(double[] a, int[] aIndex)
            {
                int k = 0;
                for (int i = 0; i != a.Length; i++)
                {
                    if (aIndex[k] == i)
                    {
                        a[i] = a[i] * 2;
                        k++;
                    }
                    else a[i] = a[i] / 2;

                }
                return a;
            }
            static void task2_23()
            {
                double[] a = new double[10] { 234, -123.12, 0.2, -34.4, 40, -7, 69, 9, -13, 243 }; 
                double[] aNotSorted = new double[10];
                Array.Copy(a, aNotSorted, a.Length);
                Array.Sort(a);
                Array.Reverse(a);
                Array.Resize(ref a, 5);
                int[] aIndex = new int[5];
                for (int j = 0; j != aIndex.Length; j++)
                {
                    for (int i = 0; i != aNotSorted.Length; i++)
                    {
                        if (a[j] == aNotSorted[i])
                        {
                            aIndex[j] = i;
                            break;
                        }
                    }
                }
                Array.Sort(aIndex);

                aNotSorted = sol2_23(aNotSorted, aIndex);
                foreach (double x in aNotSorted)
                    Console.WriteLine(x);

            }
            static double[,] sol3_2(double[,] a)
            {
                Work howToWork;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (i % 2 == 0)
                    {
                        double[] temp = new double[a.GetLength(1)];
                        for (int j = 0; j < a.GetLength(0); j++)
                            temp[j] = a[i, j];
                        howToWork = chet;
                        for (int j = 0; j < a.GetLength(0); j++)
                            a[i, j] = temp[j];
                    }
                    else
                    {
                        double[] temp = new double[a.GetLength(1)];
                        for (int j = 0; j < a.GetLength(0); j++)
                            temp[j] = a[i, j];
                        howToWork=nechet;
                        temp = howToWork(temp);
                        for (int j = 0; j < a.GetLength(0); j++)
                            a[i, j] = temp[j];
                    }
                }
                return a;
            }
            static void task3_2()
            {
                double[,] a = new double[4, 4] { {1,5,3,2},
                                                 {1,5,3,7},
                                                 {5,2,4,9},
                                                 {3,7,9,8}};
                a = sol3_2(a);
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        Console.Write(a[i, j]);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
            }
            static double sol3_3(double[] a)
            {
                double s = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (i % 2 == 1)
                    {
                        s += a[i];
                    }
                }
                return s;

            }
            static void task3_3()
            {
                Work howToWork2;
 
                double[] a = new double[10] { 2, -5, -1, -8, 9, -7, -2, 7, -5, -9 };
                int count = 1;
                double s = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    s += a[i];
                    count++;
                }
                double sr = s / count;
                if (a[0] > sr)
                {
                    howToWork2 = moreee;
                }
                else
                {
                    howToWork2 = lesss;
                }
                a = howToWork2(a);
                var sum = sol3_3(a);
                Console.WriteLine(sum);
            }
        }
    }
}
