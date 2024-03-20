namespace Emmer.Library;

public class Bucket : Container
{
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

    public void FillFromBucket(Bucket otherBucket)
    {
        // Fills the first bucket with the contents of the second bucket. 
        int temp = otherBucket.Contents;
        // try filling the first bucket.
        FillContent(temp, out int overflow);
        otherBucket.EmptyContent(temp - overflow);
    }
}