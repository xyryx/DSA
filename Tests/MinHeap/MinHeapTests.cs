using DSA.MinHeap;

namespace Tests.MinHeap
{
    public class MinHeapTests
	{
        readonly MinHeap<int> minHeap;

		public MinHeapTests()
		{
            minHeap = new MinHeap<int>();
		}

		[Fact]
		public void Add()
		{
			minHeap.Add(10);
			minHeap.Add(3);
			minHeap.Add(-4);
			minHeap.Add(0);
			minHeap.Add(20);

            Assert.Equal(-4, minHeap.Peek());

			Assert.Equal(-4, minHeap.Poll());

			Assert.Equal(0, minHeap.Peek());
		}
	}
}

