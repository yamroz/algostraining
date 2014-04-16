using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgosTraining;

namespace AlgosTrainingUnitTests
{
    [TestClass]
    public class BinaryTreeUnitTests
    {
        [TestMethod, TestCategory("Creating")]
        public void DefaultConstructor()
        {
            BinaryTree bt = new BinaryTree();
        }

        [TestMethod, TestCategory("Adding")]
        public void AddElement()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(5);
        }


        [TestMethod,TestCategory("Adding")]
        public void AddElements()
        {
            int[] elementsToAdd = { 100, 150, 200, 300, 450, 5, 3, 7, 4, 2, 6, 7, 8, 4, 3, 100 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(elementsToAdd);
            int[] expected = { 2, 3, 4, 5, 6, 7, 8, 100, 150, 200, 300, 450 };
            IComparable[] result = bt.GetElements(); 
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod, TestCategory("Adding")]
        public void AddElementsSimpleTree()
        {
            int[] elementsToAdd = { 50,10,60 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(elementsToAdd);
            int[] expected = { 10,50,60 };
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod, TestCategory("Adding")]
        public void AddElementMultipleCall()
        {
            int[] expected = { 1, 2, 3, 4, 5, 7, 9 };
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

        [TestMethod, TestCategory("Access")]
        public void GetElements()
        {
            int[] expected = {1, 2, 3, 4, 5, 7, 9};
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

        [TestMethod, TestCategory("Adding")]
        public void AddElementNullToEmptyTree()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(null);
        }

        [TestMethod, TestCategory("Adding")]
        public void AddElementNullToProperTree()
        {
            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187 };
            int[] expected = { 12, 25, 37, 50, 100, 112, 125, 150, 175, 187 }; //just sorted!
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.AddElement(null);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod,TestCategory("Removal")]
        public void RemoveElementNullFromProperTree()
        {

            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187 };
            int[] expected = { 12, 25, 37, 50, 100, 112, 125, 150, 175, 187 }; //just sorted!
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.RemoveElement(null);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod, TestCategory("Removal")]
        public void RemoveElementRemoveOneElementFromOneElementTree()
        {
            BinaryTree bt = new BinaryTree();
            bt.AddElement(100);
            bt.RemoveElement(100);
            Assert.AreEqual(0,bt.GetElements().Length);
        }

        [TestMethod, TestCategory("Removal")]
        public void RemoveElementRemoveRootFromTree()
        {
            int[] data = { 100,50,150,25,125,175,12,37,112,187 };
            int[] expected = { 12, 25, 37, 50, 112, 125, 150, 175, 187 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.RemoveElement(100);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod, TestCategory("Removal")]
        public void RemoveElementRemoveRightLeaf()
        {
            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187 };
            int[] expected = { 12, 25, 37, 50, 100, 112, 125, 150, 175 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.RemoveElement(187);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod, TestCategory("Removal")]
        public void RemoveElementRemoveLeftLeaf()
        {
            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187 };
            int[] expected = { 12, 25, 37, 50, 100, 125, 150, 175, 187 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.RemoveElement(112);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }


        [TestMethod, TestCategory("Removal")]
        public void RemoveElementLeftReplacementCase()
        {
            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187, 75, 70 };
            int[] expected = { 12, 25, 37, 50, 70, 75, 112, 125, 150, 175, 187 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            bt.RemoveElement(100);
            IComparable[] result = bt.GetElements();
            for (int i = 0; i < expected.Length; i++) Assert.AreEqual<IComparable>(expected[i], result[i], "The result and expected are different at index:" + i);
        }

        [TestMethod,TestCategory("Access")]
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

        [TestMethod, TestCategory("Access")]
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

        [TestMethod, TestCategory("Removal")]
        public void RemoveElementRemoveElementFromEmptyTree()
        {
            BinaryTree bt = new BinaryTree();
            bt.RemoveElement(5);
        }

        [TestMethod,TestCategory("Usage")]
        public void AddAndRemoveRepeatably()
        {
            int[] data = { 100, 50, 150, 25, 125, 175, 12, 37, 112, 187 };
            int[] toRemove = { 187, 112, 37, 12, 175, 125, 25, 150, 50, 100 };
            BinaryTree bt = new BinaryTree();
            bt.AddElements(data);
            foreach (int x in toRemove)
            {
                   bt.RemoveElement(x);
            }
            

        }
    }

    [TestClass]
    public class BinaryTreeLoadTests
    {
        [TestMethod,TestCategory("Load")]
        public void BinaryTreeLoadTest()
        {
            BinaryTree bt = new BinaryTree();
            Random r = new Random();
            for(int i=0;i<10000000;i++)
            {
                bt.AddElement(r.Next(1000000));
                bt.RemoveElement(r.Next(1000000));
            }

        }
    }

}
