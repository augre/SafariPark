using System.Collections;

namespace GenericList
{
	public class MyGenericList<T> : IEnumerable<T>
	{
		private T[] items = new T[DefaultCapacity];
		private int count = 0;
		private const int DefaultCapacity = 4;

		public T this[int i]
		{
			get => items[i];
			set => items[i] = value;
		}

		public void Add(T item)
		{
			if (count == items.Length)
				ResizeArray(items.Length * 2);

			items[count++] = item;
		}

		public void AddRange(T[] items)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items));

			if (count + items.Length > this.items.Length)
				ResizeArray(count + items.Length);

			Array.Copy(items, 0, this.items, count, items.Length);
			count += items.Length;
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < count; i++)
			{
				if (items[i].Equals(item))
					return true;
			}

			return false;
		}

		public int IndexOf(T item)
		{
			for (var i = 0; i < count; i++)
			{
				if (items[i].Equals(item))
					return i;
			}

			return -1;
		}

		public bool Remove(T item)
		{
			var index = IndexOf(item);
			if (index != -1)
			{
				RemoveAt(index);
				return true;
			}

			return false;
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= count)
				throw new IndexOutOfRangeException();

			for (var i = index; i < count - 1; i++)
			{
				items[i] = items[i + 1];
			}

			count--;
		}

		public void Sort()
		{
			Array.Sort(items, 0, count);
		}

		private void ResizeArray(int newSize)
		{
			var newArray = new T[newSize];
			Array.Copy(items, newArray, count);
			items = newArray;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (var i = 0; i < count; i++)
			{
				yield return items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}