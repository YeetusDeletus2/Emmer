using System;
using System.Runtime.CompilerServices;
using Emmer.Library;

namespace EmmerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            void HandleOverflow(int overflowAmount, out int overflow)
            {
                Console.WriteLine($"Container overflowed by {overflowAmount} units!");
                Console.WriteLine($"How much do you want the container to overflow? max: {overflowAmount}");

                int temp = int.Parse(Console.ReadLine());
                if (temp <= overflowAmount)
                {
                    overflow = temp;
                }

                else
                {
                    Console.WriteLine("Invalid overflow amount. Aborting container transfer.");
                    overflow = 0;
                }
            }

            /* Console.WriteLine("Making a bucket with default capacity.");
            try
            {
                Bucket bucket1 = new Bucket();
                bucket1.Overflow += HandleOverflow;
                Console.WriteLine($"Bucket Capacity: {bucket1.Capacity} || Bucket Contents: {bucket1.Contents}");

                Console.WriteLine("\nIncreasing the contents of the bucket with 8 units.");
                try
                {
                    bucket1.FillContent(8);
                    Console.WriteLine($"Bucket Capacity: {bucket1.Capacity} || Bucket Contents: {bucket1.Contents}");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"An ArgumentOutOfRangeException occurred: {e.Message}");
                }

                Console.WriteLine("\nEmptying the bucket.");
                bucket1.EmptyContent();
                Console.WriteLine($"Bucket Capacity: {bucket1.Capacity} || Bucket Contents: {bucket1.Contents}");
            }
            catch (WrongCapacityException e)
            {
                Console.WriteLine($"An WrongCapacityException occurred: {e.Message}");
            }

            Console.WriteLine("\nMaking a rainbarrel with capacity 100.");
            try
            {
                Rainbarrel rainBarrel = new Rainbarrel(RainbarrelCapacity.Hundered);
                Console.WriteLine(
                    $"Rain Barrel Capacity: {rainBarrel.Capacity} || Rain Barrel Contents: {rainBarrel.Contents}");

                Console.WriteLine("\nTrying to increase the capacity of the rain barrel.");
                try
                {
                    rainBarrel.Capacity = 120;
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"An InvalidOperationException occurred: {e.Message}");
                }

                Console.WriteLine("\nIncreaseing the contents of the rainbarrel with 110 units.");
                try
                {
                    rainBarrel.FillContent(110);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"An ArgumentOutOfRangeException occurred: {e.Message}");
                }

                Console.WriteLine(
                    $"Rain Barrel Capacity: {rainBarrel.Capacity} || Rain Barrel Contents: {rainBarrel.Contents}");
            }
            catch (WrongCapacityException e)
            {
                Console.WriteLine($"An WrongCapacityException occurred: {e.Message}");
            }

            Console.WriteLine("\nMaking an oilbarrel.");
            Oilbarrel oilBarrel = new Oilbarrel();
            Console.WriteLine(
                $"Oil Barrel Capacity: {oilBarrel.Capacity} || Oil Barrel Contents: {oilBarrel.Contents}");
            */
            /*
            Console.WriteLine("\nMaking a bucket with capacity 10.");
            try
            {
                Bucket bucket2 = new Bucket();
                Console.WriteLine($"Bucket Capacity: {bucket2.Capacity} || Bucket Contents: {bucket2.Contents}");

                Console.WriteLine("\nIncreasing the contents of the bucket with 12 units.");
                try
                {
                    bucket2.FillContent(12);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"An ArgumentOutOfRangeException occurred: {e.Message}");
                }

                Console.WriteLine($"Bucket Capacity: {bucket2.Capacity} || Bucket Contents: {bucket2.Contents}");
                Console.WriteLine("Making a standard bucket.");
                Bucket bucket3 = new Bucket(10);
                bucket3.Overflow += HandleOverflow;

                Console.WriteLine("\nFilling the new bucket with the contents of the other bucket.");
                bucket3.FillFromBucket(bucket2);
                
                Console.WriteLine(
                    $"New bucket Capacity: {bucket3.Capacity} || New bucket Contents: {bucket3.Contents}");
                Console.WriteLine($"Bucket 2 Capacity: {bucket2.Capacity} || Bucket 2 Contents: {bucket2.Contents}");
            }
            catch (WrongCapacityException e)
            {
            }
            */
            Bucket bucket = new Bucket(10); // Capacity 10
            int handledOverflow = 0;

            // Subscribe to the overflow event
            bucket.Overflow += (int amount, out int outOverflow) =>
            {
                handledOverflow = amount; // Captures the overflow amount
                outOverflow = amount; // Assigns the overflow amount to the out parameter
            };

            // Act: Fill the container with different overflow amounts
            bucket.FillContent(12);
            int overflow1 = handledOverflow; // Capture the first overflow amount
            bucket.FillContent(5);
            int overflow2 = handledOverflow; // Capture the second overflow amount

            Console.WriteLine("Overflow1: " + overflow1 + "    Overflow2:  " + overflow2);
            Console.WriteLine("Should be : 2 , 5.");
        }
    }
}