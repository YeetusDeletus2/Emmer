using System;
using System.Runtime.CompilerServices;
using Emmer.Library;

namespace EmmerApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            void HandleOverflow(int overflowAmount)
            {
                Console.WriteLine($"Bucket overflowed by {overflowAmount} units!");
            }
/*            
            Console.WriteLine("Making a bucket with default capacity.");
            try
            {
                Bucket bucket1 = new Bucket();
                Console.WriteLine($"Bucket Capacity: {bucket1.Capacity} || Bucket Contents: {bucket1.Contents}");

                Console.WriteLine("\nIncreasing the contents of the bucket with 8 units.");
                try
                {
                    bucket1.IncreaseContent(8);
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


            Console.WriteLine("\nMaking a rainbarrel with capacity 110.");
            try
            {
                Rainbarrel rainBarrel2 = new Rainbarrel(110);
                Console.WriteLine(
                    $"Rain Barrel Capacity: {rainBarrel2.Capacity} || Rain Barrel Contents: {rainBarrel2.Contents}");
            }
            catch (WrongCapacityException e)
            {
                Console.WriteLine($"An WrongCapacityException occurred: {e.Message}");
            }


            Console.WriteLine("\nMaking a rainbarrel with capacity 100.");
            try
            {
                Rainbarrel rainBarrel = new Rainbarrel(100);
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
                    rainBarrel.IncreaseContent(110);
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
            Console.WriteLine("\nMaking a bucket with capacity 10.");
            try
            {
                Bucket bucket2 = new Bucket();
                Console.WriteLine($"Bucket Capacity: {bucket2.Capacity} || Bucket Contents: {bucket2.Contents}");

                Console.WriteLine("\nIncreasing the contents of the bucket with 5 units.");
                try
                {
                    bucket2.IncreaseContent(12);
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
                try
                {
                    bucket3.FillFromBucket(bucket2);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"An ArgumentOutOfRangeException occurred: {e.Message}");
                }

                Console.WriteLine($"New bucket Capacity: {bucket3.Capacity} || New bucket Contents: {bucket3.Contents}");
                Console.WriteLine($"Bucket 2 Capacity: {bucket2.Capacity} || Bucket 2 Contents: {bucket2.Contents}");
            }
            catch (WrongCapacityException e)
            {
            }
        }
    }
}