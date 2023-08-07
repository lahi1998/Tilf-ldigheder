using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Threading;

namespace Kryptering_random
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //test område ikke opgave
            //Randoms();
            //GenerateRandomNumber(4);
            //Console.WriteLine();
            //Base64Kryptering();
            //Console.WriteLine();

            //Øvelser
            //øvelse1();

            // den dårlige er hurtigst cirka 98.33
            //RunBenchmark(øvelse2random, "øvelse2random");
            //RunBenchmark(øvelse2RandomNumberGenerator, "øvelse2RandomNumberGenerator");


            Console.ReadKey();
        }

        //test område ikke opgave
        #region
        static void Randoms()
        {
            //Brug af randoms

            Random random = new Random();

            //Genere tilfældigt nummer mellem 1 og 100.
            int randomNumber = random.Next(1, 100);
            Console.WriteLine("Tilfældigt heltal: " + randomNumber);

            //Genere tilfældigt flydende kommatal mellem 0 og 1.
            double randomDouble = random.NextDouble();
            Console.WriteLine("Tilfældigt flydende kommatal: " + randomDouble);


            //Brug af RandomNumberGenerator.Create()

            //Genere et tilfædigt byte-array med 4 bytes (til en int)
            byte[] randomBytes = new byte[4];
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomBytes);

            int radomInt = BitConverter.ToInt32(randomBytes, 0);
            Console.WriteLine("Sikker tilfældig int: " + radomInt);
        }

        //eller en metode der retunere et byte-array
        static byte[] GenerateRandomNumber(int length)
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[length];
            randomNumberGenerator.GetBytes(randomBytes);

            return randomBytes;
        }

        //Sammenhæng mellem Base64 og kryptering
        static void Base64Kryptering()
        {
            //Generer et tilfældigt byte-array med 16 bytes (128 bit)
            byte[] randomBytes = new byte[16];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomBytes);
            }

            //Base64-kodet det tilfældige byte-array
            string base64RandomData = Convert.ToBase64String(randomBytes);

            //Vis resultater
            Console.WriteLine("Tilfældige bytes: " + BitConverter.ToString(randomBytes).Replace("-", ""));
            Console.WriteLine("Base64-Kodet tilfædig data:" + base64RandomData);

            //Dekodning af base 64 tilbage til oprindlige byte-array
            byte[] decodedBase64 = Convert.FromBase64String(base64RandomData);

            //Vis det dekrypterede byte-array
            Console.WriteLine("Dekrypteret tilfældige bytes: " + BitConverter.ToString(decodedBase64).Replace("-", ""));
        }
        #endregion

        //Øvelse: Tilfældighedstest med Random og RandomNumberGenerator
        //100 tilfældige tal fra 0-999 
        public static void øvelse1()
        {
            Console.WriteLine("falsk random");
            //normal random psudo
            Random random = new Random();
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();
            Dictionary<int, int> numberCounts2 = new Dictionary<int, int>();

            int randomNumber;
            for (int i = 1; i < 100; i++)
            {
                randomNumber = random.Next(1, 100);

                if (numberCounts.ContainsKey(randomNumber))
                {
                    numberCounts[randomNumber]++;
                }
                else
                {
                    numberCounts[randomNumber] = 1;
                }
            }

            Console.WriteLine("Number Counts:");
            foreach (var number in numberCounts)
            {
                Console.WriteLine($"Number {number.Key}: {number.Value} times");
            }

            Console.WriteLine();
            Console.WriteLine("rigtig random");

            //rigtig random
            //Genere et tilfædigt byte-array med 4 bytes (til en int)
            for (int i = 1; i < 100; i++)
            {
                byte[] randomBytes = new byte[4];
                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(randomBytes);

                int radomInt = Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % 1000;
                if (radomInt == 0)
                    radomInt = 1;

                if (numberCounts2.ContainsKey(radomInt))
                {
                    numberCounts2[radomInt]++;
                }
                else
                {
                    numberCounts2[radomInt] = 1;
                }
            }

            Console.WriteLine("Number Counts:");
            foreach (var number in numberCounts2)
            {
                Console.WriteLine($"Number {number.Key}: {number.Value} times");
            }

        }

        //1000.000 tilfældige tal fra 0-999 
        public static void øvelse2random()
        {
            Console.WriteLine("falsk random");
            //normal random psudo
            Random random = new Random();
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            int randomNumber;
            for (int i = 1; i < 1000000; i++)
            {
                randomNumber = random.Next(1, 100);

                if (numberCounts.ContainsKey(randomNumber))
                {
                    numberCounts[randomNumber]++;
                }
                else
                {
                    numberCounts[randomNumber] = 1;
                }
            }

            //Console.WriteLine("Number Counts:");
            //foreach (var number in numberCounts)
            //{
            //   Console.WriteLine($"Number {number.Key}: {number.Value} times");
            //}
        }

        public static void øvelse2RandomNumberGenerator()
        {
            Dictionary<int, int> numberCounts2 = new Dictionary<int, int>();

            Console.WriteLine();
            Console.WriteLine("rigtig random");

            //rigtig random
            //Genere et tilfædigt byte-array med 4 bytes (til en int)
            for (int i = 1; i < 1000000; i++)
            {
                byte[] randomBytes = new byte[4];
                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(randomBytes);

                int radomInt = Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % 1000;
                if (radomInt == 0)
                    radomInt = 1;

                if (numberCounts2.ContainsKey(radomInt))
                {
                    numberCounts2[radomInt]++;
                }
                else
                {
                    numberCounts2[radomInt] = 1;
                }
            }

            //Console.WriteLine("Number Counts:");
            //foreach (var number in numberCounts2)
            //{
            //   Console.WriteLine($"Number {number.Key}: {number.Value} times");
            //}
        }

        private static void RunBenchmark(Action benchmarkMethod, string methodName)
        {
            long startTime = DateTime.Now.Ticks;
            benchmarkMethod();
            long endTime = DateTime.Now.Ticks;
            long elapsedTime = endTime - startTime;
            Console.WriteLine($"{methodName} tid (ticks): {elapsedTime}");
        }


    }
}
