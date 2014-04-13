using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgosTraining;

namespace AlgosTrainingUnitTests
{
    [TestClass]
    public class BinaryTreeUnitTests
    {
        [TestMethod]
        public void CreateTree()
        {
            BinaryTree bt = new BinaryTree();
        }

        [TestMethod]
        public void AddElementTest()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
        }


        [TestMethod]
        public void AddElementsTest()
        {
            int[] elementsToAdd = { 100, 150, 200, 300, 450, 5, 3, 7, 4, 2, 6, 7, 8, 4, 3, 100 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(elementsToAdd);
            int[] expected = { 2, 3, 4, 5, 6, 7, 8, 100, 150, 200, 300, 450 };
            IComparable[] result = bt.GetElements(); 
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod]
        public void AddMultipleElementsTest()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
            bt.AddElement(1);
            bt.AddElement(5);
            bt.AddElement(4);
            bt.AddElement(9);
            bt.AddElement(3);
            bt.AddElement(2);
            bt.AddElement(7);
        }

        [TestMethod]
        public void CheckSorting()
        {
            int[] expected = {1,2,3,4,5,7,9};
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
            bt.AddElement(1);
            bt.AddElement(5);
            bt.AddElement(4);
            bt.AddElement(9);
            bt.AddElement(3);
            bt.AddElement(2);
            bt.AddElement(7);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod]
        public void AddNull()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(null);
        }

        [TestMethod]
        public void RemoveElementFromProperTree()
        {
            int[] expected = { 1, 2, 4, 5, 7, 9 };
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
            bt.AddElement(1);
            bt.AddElement(5);
            bt.AddElement(4);
            bt.AddElement(9);
            bt.AddElement(3);
            bt.AddElement(2);
            bt.AddElement(7);
            bt.RemoveElement(3);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i
                + "\n result:" + result[0] + ',' + result[1] + ',' + result[2] + ',' + result[3] + ',' + result[4] + ',' + result[5] + ',' + result[6]);
        }

        [TestMethod]
        public void GetSmallestElement()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
            bt.AddElement(1);
            bt.AddElement(5);
            bt.AddElement(4);
            bt.AddElement(9);
            bt.AddElement(3);
            bt.AddElement(2);
            bt.AddElement(7);
            IComparable<int> expected = 1;
            Assert.AreEqual(expected, bt.GetSmallestElement());
        }

        [TestMethod]
        public void GetLargestElement()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
            bt.AddElement(1);
            bt.AddElement(5);
            bt.AddElement(4);
            bt.AddElement(9);
            bt.AddElement(3);
            bt.AddElement(2);
            bt.AddElement(7);
            IComparable<int> expected = 9;
            Assert.AreEqual(expected, bt.GetLargestElement());
        }

        [TestMethod]
        public void RemoveElementFromEmptyTree()
        {
            BinaryTree bt = new BinaryTree();
            bt.RemoveElement(5);
        }
    }
}
