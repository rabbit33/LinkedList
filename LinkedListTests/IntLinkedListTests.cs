using LinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LinkedListTests
{
    [TestClass]
    public class IntLinkedListTests
    {
        [TestMethod]
        public void DeleteAt_IndexIs0_DeletesFirstElement()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            linkedList.DeleteAt(0);

            LinkedList<int> expected = new LinkedList<int>(new int[] { 2, 3, 4, 5 });
            Assert.IsTrue(expected.IsEqualTo(linkedList));
        }

        [TestMethod]
        public void DeleteAt_IndexIsLast_DeletesLastElement()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            linkedList.DeleteAt(4);

            LinkedList<int> expected = new LinkedList<int>(new int[] { 1, 2, 3, 4});
            Assert.IsTrue(expected.IsEqualTo(linkedList));
        } 

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteAt_IndexIsGreaterThanListLength_NothingHappens()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            linkedList.DeleteAt(15);
        }

        [TestMethod]
        public void DeleteAt_IndexIs1_DeletesElement()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            linkedList.DeleteAt(1);

            LinkedList<int> expected = new LinkedList<int>(new int[] { 1, 3, 4, 5 });
            Assert.IsTrue(expected.IsEqualTo(linkedList));
        }

        [TestMethod]
        public void DeleteAt_IndexIsBeforeLast_DeletesElement()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });

            linkedList.DeleteAt(3);

            LinkedList<int> expected = new LinkedList<int>(new int[] { 1, 2, 3, 5 });
            Assert.IsTrue(expected.IsEqualTo(linkedList));
        }

        [TestMethod]
        public void DeleteKey_ListIsEmpty_DoesNothing()
        {
            LinkedList<int> list = new LinkedList<int>();

            list.DeleteKey(5);

            Assert.IsNull(list.Head);
        }

        [TestMethod]
        public void DeleteKey_ListHasOneElementAndKeyIsNotPresent_DoesNothing()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertFirst(5);

            list.DeleteKey(10);

            LinkedList<int> expected = new LinkedList<int>();
            expected.InsertFirst(5);

            Assert.IsTrue(expected.IsEqualTo(list));
        }

        [TestMethod]
        public void DeleteKey_ListHasOneElementEqualToKey_ListBecomesEmpty()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertFirst(5);

            list.DeleteKey(5);

            Assert.IsNull(list.Head);
        }

        [TestMethod]
        public void DeleteKey_ListHasMultipleElementsAndFirstIsKey_RemovesFirst()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertLast(5);
            list.InsertLast(6);
            list.InsertLast(7);
            list.InsertLast(8);

            list.DeleteKey(5);

            LinkedList<int> expected = new LinkedList<int>();
            expected.InsertLast(6);
            expected.InsertLast(7);
            expected.InsertLast(8);

            Assert.IsTrue(expected.IsEqualTo(list));
        }

        [TestMethod]
        public void DeleteKey_ListContainsKey_RemovesElement()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertLast(5);
            list.InsertLast(6);
            list.InsertLast(7);
            list.InsertLast(8);

            list.DeleteKey(6);

            LinkedList<int> expected = new LinkedList<int>();
            expected.InsertLast(5);
            expected.InsertLast(7);
            expected.InsertLast(8);

            Assert.IsTrue(expected.IsEqualTo(list));
        }

        [TestMethod]
        public void DeleteKey_ListDoesNotContainKey_RemovesElement()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.InsertLast(5);
            list.InsertLast(6);
            list.InsertLast(7);
            list.InsertLast(8);

            list.DeleteKey(25);

            LinkedList<int> expected = new LinkedList<int>();
            expected.InsertLast(5);
            expected.InsertLast(6);
            expected.InsertLast(7);
            expected.InsertLast(8);

            Assert.IsTrue(expected.IsEqualTo(list));
        }

        [TestMethod]
        public void CountRec_ListIsEmpty_Returns0()
        {
            LinkedList<int> list = new LinkedList<int>();

            int count = list.CountRec(list.Head);

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void CountRec_ListIsNotEmpty_ReturnsCount()
        {
            LinkedList<int> list = new LinkedList<int>(new int[] { 1, 2, 3, 4 });

            int count = list.CountRec(list.Head);

            Assert.AreEqual(4, count);
        }
    }
}
