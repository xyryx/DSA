namespace DSA.MinHeap
{
    public class MinHeap<T> where T : IComparable
	{
		protected T[] _items;
		protected int _capacity;
		protected int _size;

		public MinHeap(int capacity = 100)
		{
			_capacity = capacity;
			_items = new T[_capacity];
			_size = 0;
		}

		protected int GetLeftChildIndex(int index) => index * 2 + 1;
		protected int GetRighChildIndex(int index) => index * 2 + 2;
		protected int GetParentIndex(int index) => (index - 1) / 2;

		protected T LeftChild(int index) => _items[GetLeftChildIndex(index)];
		protected T RighChild(int index) => _items[GetRighChildIndex(index)];
		protected T Parent(int index) => _items[GetParentIndex(index)];

		protected bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;
		protected bool HasRightChild(int index) => GetRighChildIndex(index) < _size;
		protected bool HasParent(int index) => GetParentIndex(index) >= 0;

		protected void Swap(int firstIndex, int secondIndex) => (_items[firstIndex], _items[secondIndex]) = (_items[secondIndex], _items[firstIndex]);

		protected void EnsureExtraCapacity()
		{
			if(_size == _capacity)
			{
				Array.Resize<T>(ref _items, _capacity * 2);
				_capacity *= 2;
            }
		}

		protected void HeapifyDown()
		{
			var index = 0;

			while(HasLeftChild(index))
			{
				int smallerChildIndex = GetLeftChildIndex(index);

				if(HasRightChild(index) && RighChild(index).CompareTo(LeftChild(index)) < 0)
				{
					smallerChildIndex = GetRighChildIndex(index);
				}

				if (_items[index].CompareTo(_items[smallerChildIndex]) > 0 )
				{
					Swap(index, smallerChildIndex);
					index = smallerChildIndex;
				}
				else
				{
					break;
				}
			}
		}

		protected void HeapifyUp()
		{
			var index = _size - 1;

			while(HasParent(index) && Parent(index).CompareTo(_items[index]) > 0)
			{
				Swap(GetParentIndex(index), index);
				index = GetParentIndex(index);
			}
		}

		public T Peek()
		{
			return _size == 0 ? throw new InvalidOperationException() : _items[0];
		}

		public T Poll()
		{
			if (_size == 0) throw new InvalidOperationException();

			var item = _items[0];
			_items[0] = _items[_size - 1];
			_size--;

			HeapifyDown();

			return item;
		}

		public void Add(T item)
		{
			EnsureExtraCapacity();
			_items[_size] = item;
			_size++;

			HeapifyUp();
		}
	}
}

