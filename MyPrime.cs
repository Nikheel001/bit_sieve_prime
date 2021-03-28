using System;
using System.Collections.Generic;

namespace PrimeSieveTry
{
    class MyPrime
    {
        private static int LIM;
        private static bool[] arr;

        // Historical data for validating our results - the number of primes
        // to be found under some limit, such as 168 primes under 1000
        private static Dictionary<int, int> myDict = new Dictionary<int, int>
        {{ 10 , 1 },{ 100 , 25 },{ 1000 , 168 },{ 10000 , 1229 },{ 100000 , 9592 },
        { 1000000 , 78498 },{ 10000000 , 664579 },{ 100000000 , 5761455 }};

        // to reset
        static void init()
        {
            LIM = 1000000;
            int tmp = LIM >> 1;
            arr = new bool[tmp];

            for (int i = 0; i < tmp; i++)
            {
                arr[i] = true;
            }
        }

        static void runSieve()
        {
            init();

            int END = (int)Math.Sqrt(LIM);
            int i2 = 0;

            for (int i = 3; i < END; i += 2)
            {
                if (arr[i >> 1])
                {
                    i2 = i << 1;
                    for (int j = i + i2; j < LIM; j += i2)
                    {
                        arr[j >> 1] = false;
                    }
                }
            }

        }

        static void printResult(bool showResults, double duration, int passes)
        {
            if (showResults)
            {
                Console.Write("%d,", 2);
                for (int i = 3; i < LIM; i += 2)
                {
                    if (arr[i >> 1])
                    {
                        Console.Write("%d,", i);
                    }
                }
                Console.WriteLine();
            }
            int ctr = 0;
            foreach (bool i in arr)
            {
                if (i)
                {
                    ctr++;
                }
            }

            int count = 0;
            myDict.TryGetValue(LIM, out count);
            // if (!myDict.TryGetValue(LIM, out count))
            // {
            //     count = 0;
            // }
            Console.WriteLine(ctr);
            Console.WriteLine($"Passes: {passes}, Time: {duration}, Avg: {(duration / passes)}, Limit: {LIM}, Count: {count}, Valid: {count == ctr}");
        }

        public static void Main(string[] args)
        {

            var tStart = DateTime.UtcNow;
            var passes = 0;
            while ((DateTime.UtcNow - tStart).TotalSeconds < 10)
            {
                runSieve();
                passes++;
            }
            var tD = DateTime.UtcNow - tStart;
            printResult(false, tD.TotalSeconds, passes);
        }
    }
}