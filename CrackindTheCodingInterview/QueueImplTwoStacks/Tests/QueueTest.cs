using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class QueueTest
    {
        QueueImplTwoStacks.Queue<int> queue;

        [OneTimeSetUp]
        public void Init() {
            queue = new QueueImplTwoStacks.Queue<int>();
        }

        [Test]
        public void TestQueue1() {
            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Dequeue());
        }

        [Test]
        public void TestQueue2() {
            Assert.DoesNotThrow(() => queue.Dequeue());
        }

        [Test]
        public void TestQueue3() {
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
        }
    }
}
