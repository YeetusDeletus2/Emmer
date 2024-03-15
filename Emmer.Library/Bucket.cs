namespace Emmer.Library;

public class Bucket : Container
{
    public event OverflowEventHandler Overflow;

    public Bucket(int capacity)
    {
        if (capacity < 10 || capacity > 12)
        {
            throw new InvalidOperationException("The capacity of a buckets can only be between 10 and 12.");
        }

        this.Capacity = capacity;
    }


    public Bucket()
    {
        this.Capacity = 12;
    }

    public void FillFromBucket(Bucket bucket)
    {
        int temp = bucket.Contents;
        try
        {
            this.IncreaseContent(temp);
            bucket.DecreaseContent(temp);
        }
        catch (ArgumentOutOfRangeException e)
        {
            int overflowAmount = this.Contents + temp - this.Capacity;
            Overflow?.Invoke(overflowAmount);

            Console.WriteLine($"How much do you want the bucket to overflow? max: {overflowAmount}");
            int overflow = int.Parse(Console.ReadLine());
            if (overflow <= overflowAmount)
            {
                this.IncreaseContent(this.Capacity);
                bucket.DecreaseContent(temp - overflow);
            }
            else
            {
                Console.WriteLine("Invalid overflow amount. Aborting bucket transfer.");
            }
        }
    }
}