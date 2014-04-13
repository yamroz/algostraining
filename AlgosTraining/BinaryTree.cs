using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgosTraining
{
    public class TreeNode
    {
        public IComparable value = null;
        public TreeNode parent = null;
        public TreeNode left = null;
        public TreeNode right = null;
        public TreeNode(IComparable val)
        {
            value = val;
        }
    }

    public class BinaryTree
    {
        private uint size;
        private uint elToInsert;
        private TreeNode root;
        public BinaryTree()
        {
            size = 0;
            elToInsert = 0;
            this.root = null;
        }

        public void AddElement(IComparable el)
        {
            AddElement(el,ref root);
            size++;
        }

        public void AddElements(ICollection<int> inputColl) //TODO check what the fuck is wrong with ICollection<IComparable>?!?!
        {
            foreach(IComparable el in inputColl)
            {
                AddElement(el);
            }
        }

        private void AddElement(IComparable el, ref TreeNode tree, TreeNode parent = null)
        {
            if (tree != null) //we need to search existing tree
            {
                if (el.CompareTo(tree.value) == 0) return; //already present in tree, we don't insert duplicates
                if (el.CompareTo(tree.value) < 0)
                {
                    AddElement(el, ref tree.left, tree);
                }
                else AddElement(el, ref tree.right, tree);
            }
            else // we are in leaf or root, time to add
            {
                tree = new TreeNode(el);
                tree.parent = parent;
            }
        }
        
        private void GetTreeElements(TreeNode tree,ref IComparable[] result)
        {
            if (tree == null) return;
            if (tree.left != null) GetTreeElements(tree.left, ref result);
            result[elToInsert++] = tree.value;
            if (tree.right != null) GetTreeElements(tree.right, ref result);
        }

        private TreeNode GetLargestElement(TreeNode tree,TreeNode parent = null)
        {
            if (tree.right == null)
            {
                return tree;
            }
            else return GetLargestElement(tree.right, tree);
        }

        public IComparable GetLargestElement()
        {
            return GetLargestElement(root).value;
        }

        private TreeNode GetSmallestElement(TreeNode tree, TreeNode parent = null)
        {
            if (tree.left == null) return tree;
            else return GetSmallestElement(tree.left, tree);
        }

        public IComparable GetSmallestElement()
        {
            return GetSmallestElement(root).value;
        }

        /*
         * After executing this method target is in place of source and has same children
         */
        private void ExchangeForSourceRemoval(TreeNode source, TreeNode target)
        {
            target.value = source.value;
            if (source.parent.left == source) //source is left child
            {
                source.parent.left = target;
            }
            else //source is right child
            {
                source.parent.right = target;
            }
            target.left = source.left;
            target.right = source.right;
            target.parent = source.parent;
        }

        private void RemoveElement(TreeNode parent, TreeNode tree, IComparable el, bool weAreLeft)
        {
            //There is nothing to remove
            if (tree == null) return;

            //Element found:
            if (tree.value.CompareTo(el) == 0)
            {
                //1. No descendants just remove.
                if (tree.left == null && tree.right == null)
                {
                    //We are in root
                    if (parent == null)
                    {
                        this.root = null; //deleting root
                    }
                    else // we are in regular node
                    {
                        if (weAreLeft) parent.left = null;
                        else parent.right = null;
                    }
                }
                else //2. there are descendants, we need to repair tree.
                {
                    TreeNode toRemove = tree;
                    //lets choose candidate for substitute:
                    if(tree.left != null)
                    {
                        TreeNode toSubstitute = GetLargestElement(tree.left);
                        toSubstitute.parent.right = toSubstitute.left; //we are largest so parent right = our left
                        ExchangeForSourceRemoval(toSubstitute, toRemove);

                    }
                    else 
                    {
                        TreeNode toSubstitute = GetSmallestElement(tree.right);
                        toSubstitute.parent.left = toSubstitute.right; //we are smallest so parent left= our right
                        ExchangeForSourceRemoval(toSubstitute, toRemove);
                    }
                }
                --size;
            }
            //lets search further
            else
            {
                //RemoveElement(tree, (el.CompareTo(tree.value)<0) ? tree.left : tree.right,el, true); //TODO try in the future
                if (el.CompareTo(tree.value) < 0) RemoveElement(tree, tree.left, el, true); //we traverse left subtree
                else RemoveElement(tree, tree.right, el, false);//we traverse right subtree
            }
        }

        public IComparable[] GetElements()
        {
            IComparable[] result=new IComparable[size];
            elToInsert = 0;
            GetTreeElements(root, ref result);
            return result;
        }

        public void RemoveElement(IComparable el)
        {
            RemoveElement(null, root, el, true);
        }
    }
}
