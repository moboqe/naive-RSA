using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Numerics;

namespace simple_RSA
{
    class PrimeNumbers
    {
        public int P { get; set; } = 11;
        public int Q { get; set; } = 13;
        internal bool IsPrime(int n)
        {
            bool prime = true;
            if (n <= 2)
            {
                prime = false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                
                
                    if ((n % i == 0))
                    {
                        prime = false;
                        break;
                    }
                

                
            }
            return prime;
        }

    }
    static class StringExtensions
    {
        public static string Reverse(this string input)
        {
            return new string(input.ToCharArray().Reverse().ToArray());
        }
    }
    class RSA_Algorithm
    {
       
        static int Mul(int x, int e, int n)
        {
            string BINnumber = Convert.ToString(e, 2);
            int length = BINnumber.Length;
            string reversebits = BINnumber.Reverse();

            int[] binnumber = new int[length];

            for (int i = 0; i < length; i++)
            {
                binnumber[i] = Convert.ToInt32(reversebits.Substring(i, 1));
            }


            int[] array = new int[length];
            array[0] = x;
            for (int i = 1; i < length; i++)
            {
                array[i] = array[i - 1] * array[i - 1] % n;

            }

            int p = 1;
            for (int i = 0; i < length; i++)
            {
                if (binnumber[i] > 0)
                    p *= Convert.ToInt32(Math.Pow(array[i], binnumber[i]));
            }

            int Result = p % n;

            return Result;
        }


        static char[] Alphabet()
        {

            string russym = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string latsym = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            string othersym = " .,<>?/|{}[]()-_=+*!@#$%^&*;№:'\"";
            string all = russym + latsym + numbers + othersym;
            char[] dict = all.ToCharArray();
            int len = russym.Length + latsym.Length + numbers.Length + othersym.Length;


            return dict;
        }




        static int EulerFunc(int p, int q)
        {
            
            return (p - 1) * (q - 1);
        }
        static int NumberN(int p, int q)
        {
            return p * q;
        }


        private static int Gcd(int a, int b, out int x, out int y)
        {
            if (b < a)
            {
                var t = a;
                a = b;
                b = t;
            }

            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            int gcd = Gcd(b % a, a, out x, out y);

            int newY = x;
            int newX = y - (b / a) * x;

            x = newX;
            y = newY;
            return gcd;
        }
        private static bool IsCoprime(int a, int b)
        {
            return a == b ? a == 1 : a > b ? IsCoprime(a - b, b) : IsCoprime(b - a, a);
        }
        static int NumberE(int p, int q)
        {
            int phi = EulerFunc(p,q);
            int e = 0;
            for (int i = 10; i < 31; i++)
            {
                if (IsCoprime(phi, i))
                {
                    e = i;
                    break;
                }
            }
            return e;
        }

        static int NumberD(int p, int q) //
        {


            int phi = EulerFunc(p,  q);
            int e = NumberE(p,  q);
            int d;
            int k;

            int nod = Gcd(e, phi, out  d, out  k);


            return (d + phi);
        }


        static string InputText()
        {
            Console.WriteLine("Введите текст");
            return Console.ReadLine();
        }

        static int[] Encode(string text)
        {
            int[] outmas = new int[text.Length];
          
            char[] codes = Alphabet();
            for (int i = 0; i < text.Length; i++)
            {
                outmas[i] = Array.IndexOf(codes, text[i]);
            }
            return outmas;
        }

        static int[] Encrypt(int[] encodedstring, int p, int q)
        {
            int n = NumberN( p,  q);
            int e = NumberE( p,  q);
            int[] encryptedstr = new int[encodedstring.Length];
            for (int i = 0; i < encodedstring.Length; i++)
            {
                encryptedstr[i] = Mul(encodedstring[i], e, n);
            }
            return encryptedstr;
        }
        static int[] Decrypt(int[] encryptedstring, int p, int q)
        {
            int n = NumberN( p,  q);
            int d = NumberD(p,  q);

            int[] decryptedstr = new int[encryptedstring.Length];
            for (int i = 0; i < encryptedstring.Length; i++)
            {
                decryptedstr[i] = Mul(encryptedstring[i], d, n);
            }
            return decryptedstr;
        }
        static string Decode(int[] decryptedstring)
        {
            string text = "";
            char[] codes = Alphabet();
            for (int i = 0; i < decryptedstring.Length; i++)
            {
                text += codes[Convert.ToInt32(decryptedstring[i].ToString())];
            }
            return text;
        }
 
        static void Main(string[] args)
        {
            PrimeNumbers pq = new PrimeNumbers();
          
            Console.WriteLine("Введите 2 простых числа");
            
            pq.P = int.Parse(Console.ReadLine());
            pq.Q = int.Parse(Console.ReadLine());
            

            int n = NumberN(pq.P, pq.Q);

           

            int len = Alphabet().Length;

            while ((n < len-1)&&pq.IsPrime(pq.P)&&pq.IsPrime(pq.Q))
            {
                Console.Write("Числа cлишком маленькие или не простые, введите другие:");
                pq.P = int.Parse(Console.ReadLine());
                pq.Q = int.Parse(Console.ReadLine());
            }

            string data = InputText();

            int phi = EulerFunc(pq.P, pq.Q);
            n = NumberN(pq.P, pq.Q);
            int e = NumberE(pq.P, pq.Q);
            int d = NumberD(pq.P, pq.Q);
            Console.WriteLine("\nОткрытый ключ: (" + e + ", " + n + ")");
            Console.WriteLine("Секретный ключ: (" + d + ", " + n + ")");

            int[] encodedstring = Encode(data);
            
            Console.WriteLine();



            Console.Write("Строка в численном представлении\n");
            foreach (var x in encodedstring)
            Console.Write(x + " ");

            Console.WriteLine();

            int[] encryptedstring = Encrypt(encodedstring, pq.P, pq.Q);
            Console.Write("Зашифрованное сообщение\n");
            foreach (var y in encryptedstring)
            Console.Write(y + " ");
            Console.WriteLine();


            Console.Write("Расшифрованное сообщение\n");
            int[] decryptedstring = Decrypt(encryptedstring, pq.P, pq.Q);
            foreach (var z in decryptedstring)
            Console.Write(z + " ");
            Console.WriteLine();


            Console.Write("Сообщение в символьном представлении\n");
            string output = Decode(decryptedstring);
            Console.WriteLine(output); 

        //    Console.WriteLine(Decode(Decrypt(Encrypt(Encode(data)))));


            Console.ReadKey();
        }

    }
}