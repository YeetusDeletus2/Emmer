using NUnit.Framework;
using Emmer.Library;

namespace EmmerTestProject
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void Capacity_NotNegative()
        {
            var container = new Container();
            Assert.That(container.Capacity, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Content_NotNegative()
        {
            var container = new Container();
            Assert.That(container.Contents, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void Capacity_LessThan2500()
        {
            var container = new Container();
            Assert.That(container.Capacity, Is.LessThanOrEqualTo(2500));
        }

        [Test]
        public void FillAndEmpty()
        {
            var container = new Container();
            int amount = 5;
            container.IncreaseContent(amount);
            Assert.That(container.Contents, Is.EqualTo(amount));

            container.EmptyContent();
            Assert.That(container.Contents, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class BucketTests
    {
        [Test]
        public void DefaultCapacityIs12()
        {
            var bucket = new Bucket();
            int defaultCapacity = 12;
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
        public void FillFromBucket()
        {
            var bucket1 = new Bucket(10);
            var bucket2 = new Bucket(12);
            int content = 5;
            
            bucket1.IncreaseContent(content);
            bucket2.FillFromBucket(bucket1);

            Assert.That(bucket2.Contents, Is.EqualTo(content));
            Assert.That(bucket1.Contents, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class OilbarrelTests
    {
        [Test]
        public void CapacityIs159()
        {
            var oilBarrel = new Oilbarrel();
            Assert.That(oilBarrel.Capacity, Is.EqualTo(159));
        }
    }

    [TestFixture]
    public class RainbarrelTests
    {
        [Test]
        public void ValidCapacities()
        {
            Assert.DoesNotThrow(() => new Rainbarrel(80));
            Assert.DoesNotThrow(() => new Rainbarrel(100));
            Assert.DoesNotThrow(() => new Rainbarrel(120));
        }

        [Test]
        public void InvalidCapacities()
        {
            Assert.Throws<InvalidOperationException>(() => new Rainbarrel(50));
            Assert.Throws<InvalidOperationException>(() => new Rainbarrel(110));
            Assert.Throws<InvalidOperationException>(() => new Rainbarrel(130));
        }
    }
}