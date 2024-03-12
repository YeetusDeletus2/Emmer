namespace Emmer.Library;

public class Bucket : Container
{
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
            Console.WriteLine($"An ArgumentOutOfRangeException occurred: {e.Message}");
        }
    }
}