namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class BucketTests
{
    [Test]
    public void BucketConstructorException()
    {
        Assert.Throws<WrongCapacityException>(() => new Bucket(2501));
    }

    [Test]
    public void CapacityPropTest()
    {
        int capacity = Bucket.DefaultCapacity;
        Bucket bucket = new Bucket(capacity);
        Assert.That(bucket.Capacity, Is.EqualTo(capacity));
    }

    [Test]
    public void DefaultCapacityIs12()
    {
        Bucket bucket = new Bucket();
        int defaultCapacity = Bucket.DefaultCapacity;
        Assert.That(bucket.Capacity, Is.EqualTo(defaultCapacity));
    }

    [Test]
    public void CustomCapacity()
    {
        int capactity = 10;
        Bucket bucket = new Bucket(capactity);
        Assert.That(bucket.Capacity, Is.EqualTo(capactity));
    }

    [Test]
    public void FillFromBucket_IncreaseContentAndDecreaseContent_Success()
    {
        Bucket bucket = new Bucket();
        Bucket bucket2 = new Bucket();
        bucket.FillContent(5);

        bucket2.FillFromBucket(bucket);

        // Assert
        Assert.That(bucket.Contents, Is.EqualTo(0));
        Assert.That(bucket2.Contents, Is.EqualTo(5));
    }
    
    [Test]
    public void EmptyBucket()
    {
        Bucket bucket = new Bucket();
        bucket.FillContent(10);
        bucket.EmptyContent();
        Assert.That(bucket.Contents, Is.EqualTo(0));
    }
    
    [Test]
    public void OverflowEvent_IsTriggered_WhenBucketContentsExceedCapacity()
    {
        Bucket bucket = new Bucket(10);
        int overflowAmount = 0;

        bucket.Overflow += (int amount, out int outOverflow) =>
        {
            overflowAmount = amount;
            outOverflow = amount;
        };

        bucket.FillContent(12);

        Assert.That(overflowAmount, Is.EqualTo(2));
    }

    [Test]
    public void OverflowEvent_HandlesCorrectly_WhenBucketHasAlreadyBeenFilled()
    {
        Bucket bucket = new Bucket(10); 
        int handledOverflow = 0;

        bucket.Overflow += (int amount, out int outOverflow) =>
        {
            handledOverflow = amount; 
            outOverflow = amount; 
        };

        bucket.FillContent(12);
        int overflow1 = handledOverflow; 
        bucket.FillContent(5);
        int overflow2 = handledOverflow; 

        Assert.That(overflow1, Is.EqualTo(2));
        Assert.That(overflow2, Is.EqualTo(5));
    }
}