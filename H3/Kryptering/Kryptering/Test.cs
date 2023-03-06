using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Kryptering
{
    public class Test
    {
        // Test of random generated numbers
        public void RandomNumberTest(int numberOfTests)
        {
            if (numberOfTests < 1)
            {
                Console.WriteLine("Number of tests must be greater than 0");
                return;
            }

            // List of stopwatches (used to determine average)
            List<Stopwatch> stopwatches = new List<Stopwatch>();

            // Test of secure random numbers
            for (int i = 0; i < numberOfTests; i++)
            {
                stopwatches.Add(SecureRandomNumberTest());
            }

            Console.WriteLine("Average time for secure numbers: " + stopwatches.Average(x => x.ElapsedMilliseconds) + " ms");

            // Clears stopwatches for next test
            stopwatches.Clear();

            // Test of non-secure random numbers
            for (int i = 0; i < numberOfTests; i++)
            {
                stopwatches.Add(NonSecureRandomNumberTest());
            }

            Console.WriteLine("Average time for non-secure numbers: " + stopwatches.Average(x => x.ElapsedMilliseconds) + " ms");
        }


        // Generates 10000 random secure numbers and returns the time it took (used for testing speed)
        private Stopwatch SecureRandomNumberTest()
        {
            // List of random numbers
            List<int> randomNumbers = new List<int>();

            // Stopwatch for measuring time
            Stopwatch stopwatch = new Stopwatch();

            #region Secure random numbers
            // Generates 10000 random secure numbers within range 1-1000
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                randomNumbers.Add(Encryption.GenerateSecureRandomInt(1, 1000));
            }
            stopwatch.Stop();
            #endregion

            return stopwatch;
        }


        // Generates 10000 random non-secure numbers and returns the time it took (used for testing speed)
        private Stopwatch NonSecureRandomNumberTest()
        {
            // List of random numbers
            List<int> randomNumbers = new List<int>();

            // Stopwatch for measuring time
            Stopwatch stopwatch = new Stopwatch();

            #region Non-secure random numbers
            // Generates 100000 random numbers within range 1-1000
            stopwatch.Start();
            for (int i = 0; i < 100000; i++)
            {
                randomNumbers.Add(Encryption.GenerateRandomInt(1, 1000));
            }
            stopwatch.Stop();
            #endregion

            return stopwatch;
        }
    }
}
