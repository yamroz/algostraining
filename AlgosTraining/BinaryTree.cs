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
            if (el == null) return;
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
            //target.value = source.value;
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

        public void RemoveElement(IComparable el)
        {
            RemoveElement(null, root, el);
        }

        private void RemoveElement(TreeNode parent, TreeNode tree, IComparable el)
        {
            //There is nothing to remove
            if (tree == null || el == null) return;

            //Element found:
            if (tree.value.CompareTo(el) == 0)
            {
                //A. No descendants just remove.
                if (tree.left == null && tree.right == null)
                {
                    //We are in root
                    if (parent == null)
                    {
                        this.root = null; //deleting root
                    }
                    else // we are in regular node, remove us from parent
                    {
                        if (parent.left==tree) parent.left = null;
                        else parent.right = null;
                    }
                }
                else //B. there are descendants, we need to repair tree.
                {
                    //choose candidate for replacemnt
                    TreeNode replacement = null;
                    if(tree.left != null)replacement = GetLargestElement(tree.left);
                    else replacement= GetLargestElement(tree.right);

                    tree.value = replacement.value;
                    //repairing tree
                    if (replacement.left == null && replacement.right == null) //replacement has no descendants
                    {
                        if (replacement == replacement.parent.left) replacement.parent.left = null;
                        else replacement.parent.right = null;
                    }
                    else //replacement has descendants
                    {
                        if (replacement == replacement.parent.left)
                        {
                            replacement.parent.left = replacement.left;
                            replacement.left.parent = replacement.parent;
                        }
                        else
                        {
                            replacement.parent.right = replacement.right;
                            replacement.right.parent = replacement.parent;
                        }
                    }
                }
                --size;
            }
            //lets search further
            else
            {
                //RemoveElement(tree, (el.CompareTo(tree.value)<0) ? tree.left : tree.right,el, true); //TODO try in the future
                if (el.CompareTo(tree.value) < 0) RemoveElement(tree, tree.left, el); //we traverse left subtree
                else RemoveElement(tree, tree.right, el);//we traverse right subtree
            }
        }
        
        public IComparable[] GetElements()
        {
            IComparable[] result=new IComparable[size];
            elToInsert = 0;
            GetTreeElements(root, ref result);
            return result;
        }


    }
}
