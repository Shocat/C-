using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApplication37
{
    class Program
    {
         double PI = Math.Acos(-1.0);

        static void FFT(List<Complex> a, bool invert)
        {
            int n = a.Count;
            for (int i = 1, j = 0; i < n; i++)
            {
                int bit = n >> 1;
                while (j >= bit)
                {
                    j -= bit;
                    bit >>= 1;
                }
                j += bit;
                if (i < j)
                {
                    Complex temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
            }
            for (int len = 2; len <= n; len <<= 1)
            {
                double ang = 2 * PI / len * (invert ? -1 : 1);
                Complex wlen = new Complex(Math.Cos(ang), Math.Sin(ang));
                for (int i = 0; i < n; i += len)
                {
                    Complex w = Complex.One;
                    for (int j = 0; j < len / 2; j++)
                    {
                        Complex u = a[i + j];
                        Complex v = a[i + j + len / 2] * w;
                        a[i + j] = u + v;
                        a[i + j + len / 2] = u - v;
                        w *= wlen;
                    }
                }
            }
            if (invert)
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] /= n;
                }
            }
        }

        static List<int> Multiply(List<int> a, List<int> b)
        {
            List<Complex> fa = new List<Complex>();
            foreach (int num in a)
            {
                fa.Add(new Complex(num, 0));
            }

            List<Complex> fb = new List<Complex>();
            foreach (int num in b)
            {
                fb.Add(new Complex(num, 0));
            }

            int n = 1;
            while (n < Math.Max(a.Count, b.Count))
            {
                n <<= 1;
            }
            n <<= 1;

            while (fa.Count < n)
            {
                fa.Add(Complex.Zero);
            }

            while (fb.Count < n)
            {
                fb.Add(Complex.Zero);
            }

            FFT(fa, false);
            FFT(fb, false);

            for (int i = 0; i < n; i++)
            {
                fa[i] *= fb[i];
            }

            FFT(fa, true);

            List<int> result = new List<int>();
            int carry = 0;

            for (int i = 0; i < n; i++)
            {
                int val = (int)Math.Round(fa[i].Real) + carry;
                carry = val / 10;
                result.Add(val % 10);
            }

            while (carry > 0)
            {
                result.Add(carry % 10);
                carry /= 10;
            }

            result.Reverse();

            while (result.Count > 1 && result[0] == 0)
            {
                result.RemoveAt(0);
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<int> a = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> b = new List<int> { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            long x = 0, y = 0;

            for (int i = 0; i < a.Count; i++)
            {
                x = x * 10 + a[i];
            }

            for (int i = 0; i < b.Count; i++)
            {
                y = y * 10 + b[i];
            }

            Console.WriteLine("a = " + x);
            Console.WriteLine("b = " + y);

            List<int> ans = Multiply(a, b);

            for (int i = ans.Count - 1; i >= 0; i--)
            {
                Console.Write(ans[i]);
            }

            Console.WriteLine();

            int index = ans.Count - 1;

            while (index >= 0 && ans[index] == 0)
            {
                index--;
            }

            if (index < 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = index; i >= 0; i--)
                {
                    Console.Write(ans[i]);
                }
            }
        }
    }
}
