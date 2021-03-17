using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace simple_RSA
{
    /*
    class Program
    {
       

        const long p = 3;
        const long q = 7;
       
        //const long [] codes = new long[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        static long numberN(long key1, long key2)
        {
            long n = 0;
            n = key1 * key2;
            return n;
        }
        static long EulerFunction(long key1, long key2)
        {
            long result = (p - 1) * (q - 1);
            return result;
        }
        static long NumberD(long euler, long key1, long key2)
        {
            long d = 0;
            long e = euler;
            long k = 7;
            long phi = EulerFunction(key1, key2);
            d = (k * phi + 1) / e;
            return d;
        }
      //  static long Encode { }
        static long[] Encrypt(string text, long key1, long key2, long e)
        {
            long n = numberN(key1, key2);
        ///   byte[] bytes = Encoding.UTF8.GetBytes(text);

            long[] encryptedText = new long[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText[i] = Convert.ToInt32(Math.Pow(bytes[i], e)) % n;
                //encryptedText[i] = Convert.ToInt32(Math.Pow((int)text[i], e)) % n;
            }

            return encryptedText;
        }
        static string[] Decrypt(long[] data, long key1, long key2, long e)
        {
            long d = NumberD(e, key1, key2);

            long n = numberN(key1, key2);
            // byte[] bytes = Encoding.UTF8.GetBytes(text);

            long[] decryptedTextnumbers = new long[data.Length];
            string[] decryptedText = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {

                decryptedTextnumbers[i] = Convert.ToInt64(Math.Pow(data[i], d)) % n;
                decryptedText[i] = Convert.ToString((char)decryptedTextnumbers[i]);
            }

            return decryptedText;
        }

        static void Man(string[] args)
        {
            long phi = EulerFunction(p, q);
            Console.WriteLine("Введите число в диапазоне от 1 до " + phi);
            long euler = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Открытый ключ: " + euler + ", " + numberN(p, q));
            Console.WriteLine("Секретный ключ: " + NumberD(euler, p, q) + ", " + numberN(p, q));

            Console.WriteLine("Введите исходную строку");
             string Data = Convert.ToString(Console.ReadLine());

             long[] intdata = new long[Data.Length];
             for (int i = 0; i < intdata.Length; i++)
             {
                 intdata[i] = Data[i];
             }
            long IntData = Convert.ToInt64(Console.ReadLine());


           // byte[] bytes = Encoding.UTF8.GetBytes("1");
           //for (int i = 0; i < bytes.Length; i++)
           //    Console.WriteLine(bytes[i]+"  ");



            long[] encryptedData = Encrypt(Data, p, q, euler);
            for (int i = 0; i < encryptedData.Length; i++)
                Console.Write(encryptedData[i] + "  ");

            Console.WriteLine();



            long d = NumberD(euler, p, q);
            Console.WriteLine("d= " + d);

            long n = numberN(p, q);
            Console.WriteLine("n= " + n);

            long[] decryptedTextnumbers = new long[encryptedData.Length];
            string[] decryptedText = new string[encryptedData.Length];


            //Console.WriteLine(encryptedData[0] + "  " + d);
            //  Console.WriteLine(encryptedData[1] + "  " + d);
            // Console.WriteLine(encryptedData[2] + "  " + d);
            //long result=(Convert.ToInt32(Math.Pow(encryptedData[0], d)));

            /*  Console.WriteLine("Длина зашифрованного массива " + encryptedData.Length);
         for (int i = 0; i < encryptedData.Length; i++)
              {
                 // Console.Write("ASCII код символа "+encryptedData[i]+"  \n");
               long k=Convert.ToInt64(Math.Pow(encryptedData[i], d));
               Console.WriteLine(k);
                  decryptedTextnumbers[i] = k % n;
                  Console.Write(decryptedTextnumbers[i] + " \n");
                  decryptedText[i] = Convert.ToString(Convert.ToChar(decryptedTextnumbers[i]));
                //  Console.Write(decryptedText[i] + " \n");
              }

               for (int i = 0; i < decryptedText.Length; i++)
                  Console.Write(decryptedText[i] + "  ");

              Console.WriteLine(Convert.ToChar(7));*/






            /* string[] decryptedData = Decrypt(encryptedData,p,q,euler);
             Console.WriteLine(decryptedData[0]);
             for (int i = 0; i < decryptedData.Length; i++)
                 Console.WriteLine(decryptedData[i] + "  ");*/


        /*    Console.ReadKey();
        }

    }*/
}
