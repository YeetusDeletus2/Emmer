namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class ContainerTests
{
    [Test]
    public void ValidCapacities()
    {
        Container container1 = new Container();
        Assert.DoesNotThrow(() => container1.Capacity = 240);
        Container container2 = new Container();
        Assert.DoesNotThrow(() => container2.Capacity = 2499);
        Container container3 = new Container();
        Assert.DoesNotThrow(() => container3.Capacity = 1);
    }

    [Test]
    public void InvalidCapacities()
    {
        Container container1 = new Container();
        Assert.Throws<ArgumentOutOfRangeException>(() => container1.Capacity = -1);
        Container container2 = new Container();
        Assert.Throws<ArgumentOutOfRangeException>(() => container1.Capacity = 2501);
    }

    [Test]
    public void CannotChangeCapacity()
    {
        Container container1 = new Container();
        container1.Capacity = 50;
        Assert.Throws<InvalidOperationException>(() => container1.Capacity = 40);
    }

    [Test]
    public void Contents_Setter()
    {
        Bucket bucket = new Bucket();
        bucket.FillContent(10);
        Assert.That(bucket.Contents, Is.EqualTo(10));
    }

    [Test]
    public void Content_NotNegative()
        // default
    {
        Container container = new Container();
        Assert.That(container.Contents, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void DecreaseContents()
    {
        Bucket bucket = new Bucket();
        bucket.FillContent(10);
        bucket.EmptyContent(5);
        Assert.That(bucket.Contents, Is.EqualTo(5));
    }

    [Test]
    public void DecreaseContentsException()
    {
        Bucket bucket = new Bucket();
        bucket.FillContent(10);
        Assert.Throws<ArgumentOutOfRangeException>(() => bucket.EmptyContent(11));
    }
}