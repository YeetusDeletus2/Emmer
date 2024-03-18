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
        var bucket = new Bucket();
        int defaultCapacity = Bucket.DefaultCapacity;
        Assert.That(bucket.Capacity, Is.EqualTo(defaultCapacity));
    }

    [Test]
    public void CustomCapacity()
    {
        int capactity = 10;
        var bucket = new Bucket(capactity);
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

    /*
    [Test]
    public void FillFromBucket_ThrowsException_ContentNotIncreased()
    {
        // Arrange
        Bucket bucket = new Bucket();
        Bucket bucket2 = new Bucket(10);
        bucket.FillContent(12);
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        bucket2.FillFromBucket(bucket);

        Assert.That(stringWriter.ToString(), Is.EqualTo("An ArgumentOutOfRangeException occurred: Cannot increase content above the capacity. (Parameter 'amount')\r\n"));
    }
*/
    [Test]
    public void EmptyBucket()
    {
        var bucket = new Bucket();
        bucket.FillContent(10);
        bucket.EmptyContent();
        Assert.That(bucket.Contents, Is.EqualTo(0));
    }
}