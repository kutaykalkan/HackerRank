using NUnit.Framework;
using RunningMedian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMedian.Tests
{
    [TestFixture]
    public class MinHeapTests
    {
        [Test]
        public void pushTest() {
            MinHeap heap = new MinHeap();
            heap.Push(12);
            heap.Push(4);

            Assert.AreEqual(4, heap.Peek());
        }
    }
}