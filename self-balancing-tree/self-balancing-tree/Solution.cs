using System;
using System.Collections.Generic;
using System.Text;

namespace self_balancing_tree
{
    public class Solution
    {
        Node root;

        public void Insert(int value)
        {
            Node newItem = new Node(value);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Value < current.Value)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = Balance_tree(current);
            }
            else if (n.Value > current.Value)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = Balance_tree(current);
            }
            return current;
        }
        private Node Balance_tree(Node current)
        {
            int b_factor = HeigthFactor(current);
            if (b_factor > 1)
            {
                if (HeigthFactor(current.Left) > 0)
                {
                    current = RotateLeftToLeft(current);
                }
                else
                {
                    current = RotateLeftToRight(current);
                }
            }
            else if (b_factor < -1)
            {
                if (HeigthFactor(current.Right) > 0)
                {
                    current = RotateRigthToLeft(current);
                }
                else
                {
                    current = RotateRightToRight(current);
                }
            }
            return current;
        }
        public void Delete(int target)
        {
            root = Delete(root, target);
        }
        private Node Delete(Node current, int target)
        {
            Node parent;
            if (current == null)
            { return null; }
            else
            {
                if (target < current.Value)
                {
                    current.Left = Delete(current.Left, target);
                    if (HeigthFactor(current) == -2)
                    {
                        if (HeigthFactor(current.Right) <= 0)
                        {
                            current = RotateRightToRight(current);
                        }
                        else
                        {
                            current = RotateRigthToLeft(current);
                        }
                    }
                }
                else if (target > current.Value)
                {
                    current.Right = Delete(current.Right, target);
                    if (HeigthFactor(current) == 2)
                    {
                        if (HeigthFactor(current.Left) >= 0)
                        {
                            current = RotateLeftToLeft(current);
                        }
                        else
                        {
                            current = RotateLeftToRight(current);
                        }
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Value = parent.Value;
                        current.Right = Delete(current.Right, parent.Value);
                        if (HeigthFactor(current) == 2)
                        {
                            if (HeigthFactor(current.Left) >= 0)
                            {
                                current = RotateLeftToLeft(current);
                            }
                            else { current = RotateLeftToRight(current); }
                        }
                    }
                    else
                    {
                        return current.Left;
                    }
                }
            }
            return current;
        }
        public void Find(int key)
        {
            if (Find(key, root).Value == key)
            {
                Console.WriteLine("{0} was found!", key);
            }
            else
            {
                Console.WriteLine("Nothing found!");
            }
        }
        private Node Find(int target, Node current)
        {

            if (target < current.Value)
            {
                if (target == current.Value)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Value)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }

        }
        public void PrintValues()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            PrintInOrder(root);
            Console.WriteLine();
        }
        private void PrintInOrder(Node current)
        {
            if (current != null)
            {
                PrintInOrder(current.Left);
                Console.Write("({0}) ", current.Value);
                PrintInOrder(current.Right);
            }
        }
        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int GetHeight(Node current)
        {
            var height = 0;
            if (current != null)
            {
                int l = GetHeight(current.Left);
                int r = GetHeight(current.Right);
                int m = Max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int HeigthFactor(Node current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRightToRight(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private Node RotateLeftToLeft(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLeftToRight(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRightToRight(pivot);
            return RotateLeftToLeft(parent);
        }
        private Node RotateRigthToLeft(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLeftToLeft(pivot);
            return RotateRightToRight(parent);
        }
    }
}
