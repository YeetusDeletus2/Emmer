namespace Emmer.Library;

public class Bucket : Container
{
    public event OverflowEventHandler Overflow;
    public const int DefaultCapacity = 12;

    public Bucket(int capacity)
    {
        // Creates a bucket of which the capacity should be between 10 and 2500
        if (capacity < 10 || capacity > 2500)
        {
            throw new WrongCapacityException(nameof(capacity),
                "The capacity of a buckets can only be between 10 and 2500.");
        }

        Capacity = capacity;
    }


    public Bucket() : this(DefaultCapacity)
    {
        // Creates a bucket with the default capacity
    }

    public void FillFromBucket(Bucket bucket)
    {
        // Fills the first bucket with the contents of the second bucket. 
        int temp = bucket.Contents;
        try
        {
            // try filling the first bucket.
            FillContent(temp);
            bucket.EmptyContent(temp);
        }
        catch (ArgumentOutOfRangeException e)
        {
            // The bucket is overflowing.
            int overflowAmount = this.Contents + temp - this.Capacity;
            Overflow?.Invoke(overflowAmount);

            Console.WriteLine($"How much do you want the bucket to overflow? max: {overflowAmount}");
            int overflow = int.Parse(Console.ReadLine());
            if (overflow <= overflowAmount)
            {
                FillContent(this.Capacity);
                bucket.EmptyContent(temp - overflow);
            }
            else
            {
                Console.WriteLine("Invalid overflow amount. Aborting bucket transfer.");
            }
        }
    }
}