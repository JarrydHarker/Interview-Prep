using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace InterviewPrep
{
    internal class BinaryTree
    {
        public TreeNode? root = null;

        public BinaryTree()
        {

        }

        public void AddNode(int data)
        {
            if (root != null)
            {
                root.Insert(data);
            } else
            {
                root = new TreeNode(data);
            }
        }

        public void Reverse(TreeNode? currentNode = null) //RE-BESII
        {
            if (currentNode == null) currentNode = root;//handle null args

            if (currentNode.leftNode == null && currentNode.rightNode == null) return;//B - check that Both are null
            else//E - else
            {
                TreeNode temp = currentNode.leftNode;//S - swap

                currentNode.leftNode = currentNode.rightNode;
                currentNode.rightNode = temp;
            }
            //II
            if (currentNode.leftNode != null) Reverse(currentNode.leftNode);
            if (currentNode.rightNode != null) Reverse(currentNode.rightNode);
        }

        public string PrintTree()
        {
            TreeNode current = root;
            string output = string.Empty;

            if (current != null)
            {
                output += PrintNode(current);
            }

            return output;
        }

        private string PrintNode(TreeNode node)
        {
            string output = string.Empty;

            if (node != null)
            {
                output += $"[{node.data}]\n";

                if (node.leftNode != null)
                {
                    output += "/ ";
                    output += "\n" + PrintNode(node.leftNode);
                } else output += "  ";

                if (node.rightNode != null)
                {
                    output += " \\";
                    output += "\n" + PrintNode(node.rightNode);
                } else output += "  ";
            }

            return output;
        }

        public void RemoveNode(int data)
        {

        }

        public TreeNode? GetNode(int data) { return root; }
    }

    public class TreeNode
    {
        public int data;
        public TreeNode leftNode;
        public TreeNode rightNode;

        public TreeNode(int data)
        {
            this.data = data;
        }

        internal void Insert(int data)
        {
            if (data < this.data)
            {
                if (leftNode == null)
                {
                    leftNode = new TreeNode(data);
                } else
                {
                    leftNode.Insert(data);
                }
            } else
            {
                if (rightNode == null)
                {
                    rightNode = new TreeNode(data);
                } else
                {
                    rightNode.Insert(data);
                }
            }
        }
    }
}
