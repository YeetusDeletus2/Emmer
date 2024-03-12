namespace EmmerTest;

using Emmer.Library;

[TestFixture]
public class ContainerTests
{
    [Test]
    public void ValidCapacities()
    {
        var container1 = new Container();
        Assert.DoesNotThrow(() => container1.Capacity = 240);
        var container2 = new Container();
        Assert.DoesNotThrow(() => container2.Capacity = 2499);
        var container3 = new Container();
        Assert.DoesNotThrow(() => container3.Capacity = 1);
    }

    [Test]
    public void InvalidCapacities()
    {
        var container1 = new Container();
        Assert.Throws<ArgumentOutOfRangeException>(() => container1.Capacity = -1);
        var container2 = new Container();
        Assert.Throws<ArgumentOutOfRangeException>(() => container1.Capacity = 2501);
    }

    [Test]
    public void CannotChangeCapacity()
    {
        var container1 = new Container();
        container1.Capacity = 50;
        Assert.Throws<InvalidOperationException>(() => container1.Capacity = 40);
    }

    [Test]
    public void Contents_Setter()
    {
        var bucket = new Bucket();
        bucket.Contents = 10;
        Assert.That(bucket.Contents, Is.EqualTo(10));
    }

    [Test]
    public void Content_NotNegative()
    {
        var container = new Container();
        Assert.That(container.Contents, Is.GreaterThanOrEqualTo(0));
    }

    [Test]
    public void IncreaseContentsException()
    {
        var bucket = new Bucket(12);
        Assert.Throws<ArgumentOutOfRangeException>(() => bucket.IncreaseContent(13));
    }

    [Test]
    public void DecreaseContents()
    {
        var bucket = new Bucket();
        bucket.Contents = 10;
        bucket.DecreaseContent(5);
        Assert.That(bucket.Contents, Is.EqualTo(5));
    }
    
    [Test]
    public void DecreaseContentsException()
    {
        var bucket = new Bucket();
        bucket.Contents = 10;
        Assert.Throws<ArgumentOutOfRangeException>(() => bucket.DecreaseContent(11));
    }
}