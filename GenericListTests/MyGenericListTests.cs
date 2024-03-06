using GenericList;
using Xunit;
using Assert = Xunit.Assert;

namespace GenericList.Tests
{
	public class MyGenericListTests
	{
		private MyGenericList<int> myIntList;
		private MyGenericList<string> myStringList;
		private int[] intRange;

		private void initIntList()
		{
			this.myIntList = new MyGenericList<int>();
			this.intRange = new int[] {5, 1, 2, 3, 4, 5};
			myIntList.AddRange(intRange);
		}

		private void initStringList()
		{
			myStringList = new MyGenericList<string>() { "rafa", "lufa", "klafa", "bumm", "umm", "laa" };
			myStringList.Add("bumm");
			var range = new[] { "vumm", "rumm" };
			myStringList.AddRange(range);
		}

		[Fact()]
		public void AddTest()
		{
			myIntList = new MyGenericList<int>();
			myIntList.Add(1);
			myIntList.Add(1);
			myIntList.Add(100000000);
			Assert.Equal(1, myIntList[0]);
			Assert.Equal(1, myIntList[1]);
			Assert.Equal(100000000, myIntList[2]);
		}

		[Fact()]
		public void AddRangeTest()
		{
			initIntList();
			Assert.Equal(5, myIntList[5]);
			Assert.Equal(4, myIntList[4]);
			Assert.Equal(3, myIntList[3]);
			Assert.Equal(5, myIntList[0]);
		}

		[Fact()]
		public void ContainsTest()
		{
			initIntList();
			Assert.True(myIntList.Contains(3));
			Assert.True(myIntList.Contains(1));
			Assert.False(myIntList.Contains(30));
		}

		[Fact()]
		public void IndexOfTest()
		{
			initIntList();
			Assert.True(myIntList.IndexOf(1) == 1);
			Assert.True(myIntList.IndexOf(5) == 0);
			Assert.False(myIntList.IndexOf(5) == 6);
		}


		[Fact()]
		public void RemoveTest()
		{
			initIntList();
			Assert.True(myIntList.Remove(5));
			Assert.True(myIntList[0] == 1);
			Assert.True(myIntList[4] == 5);
		}

		[Fact()]
		public void RemoveAtTest()
		{
			initIntList();
			Assert.True(myIntList[0] == 5);
			myIntList.RemoveAt(0);
			Assert.True(myIntList[0] == 1);
			myIntList.RemoveAt(4);
			Assert.True(myIntList[3] == 4);
		}

		[Fact()]
		public void SortTest()
		{
			initIntList();
			myIntList.Sort();
			Assert.True(myIntList[0] == 1);
			Assert.True(myIntList[1] == 2);
			Assert.True(myIntList[2] == 3);
			Assert.True(myIntList[3] == 4);
			Assert.True(myIntList[4] == 5);
			Assert.True(myIntList[5] == 5);
		}

		[Fact()]
		public void AddTest1()
		{
			initStringList();
			Assert.True(myStringList[8] == "rumm");
			Assert.True(myStringList[7] == "vumm");
			Assert.True(myStringList[0] == "rafa");
		}

		[Fact()]
		public void ContainsTest1()
		{
			initStringList();
			Assert.True(myStringList.Contains("rumm"));
			Assert.False(myStringList.Contains("tumm"));
		}

		[Fact()]
		public void IndexOfTest1()
		{
			initStringList();
			Assert.True(myStringList.IndexOf("rafa") == 0);
			Assert.True(myStringList.IndexOf("vumm") == 7);
			Assert.False(myStringList.IndexOf("vumm") == 6);
		}

		[Fact()]
		public void RemoveTest1()
		{
			initStringList();
			Assert.True(myStringList.Remove("rafa"));
			Assert.False(myStringList.Contains("rafa"));
		}

		[Fact()]
		public void RemoveAtTest1()
		{
			initStringList();
			myStringList.RemoveAt(0);
			Assert.False(myStringList.Contains("rafa"));
			Assert.True(myStringList[0] == "lufa");
		}

		[Fact()]
		public void SortTest1()
		{
			initStringList();
			myStringList.Sort();
			Assert.True(myStringList[0] == "bumm");
			Assert.True(myStringList[8] == "vumm");
		}

		[Fact()]
		public void GetEnumeratorTest()
		{
			initIntList();

			for (int i = 0; i < intRange.Length; i++)
			{
				Assert.True(myIntList[i] == intRange[i]);
			}
		}

		[Fact()]
		public void CheckOutOfBound()
		{
			initIntList();
			Assert.Throws<IndexOutOfRangeException>(() => myIntList[15]);
		}
	}
}