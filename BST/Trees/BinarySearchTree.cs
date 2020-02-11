using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node 
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node LeftChild { get; set; }

        public Node RightChild { get; set; }
    }

    private Node root;

    private BinarySearchTree(Node root) 
    {
        this.Copy(root);
    }

    private void Copy(Node root) 
    {
        if (root == null)
        {
            return;
        }

        this.Insert(root.Value);
        this.Copy(root.LeftChild);
        this.Copy(root.RightChild);
    }

    public BinarySearchTree()
    {

    }

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current != null)
        {
            int comparer = current.Value.CompareTo(value);

            if (comparer > 0)
            {
                parent = current;
                current = current.LeftChild;
            }
            else if (comparer < 0)
            {
                parent = current;
                current = current.RightChild;
            }
        }

        Node newNode = new Node(value);

        if (newNode.Value.CompareTo(parent.Value) < 0)
        {
            parent.LeftChild = newNode;
        }
        else
        {
            parent.RightChild = newNode;
        }
    }

    public bool Contains(T value)
    {
        Node current = this.root;

        while (current != null)
        {
            int comparer = current.Value.CompareTo(value);

            if (comparer > 0)
            {
                current = current.LeftChild;
            }
            else if (comparer < 0)
            {
                current = current.RightChild;
            }
            else
            {
                return true;
            }
        }

        return false;
    }

    public void DeleteMin()
    {
        if (this.root == null)
        {
            return;
        }

        Node parent = null;
        Node current = this.root;

        while (current.LeftChild != null)
        {
            parent = current;
            current = current.LeftChild;
        }

        if (parent == null)
        {
            this.root = current.LeftChild;
        }
        else
        {
            parent.LeftChild = current.RightChild;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        Node current = this.root;

        while (current != null)
        {
            int comparer = current.Value.CompareTo(item);

            if (comparer > 0)
            {
                current = current.LeftChild;
            }
            else if (comparer < 0)
            {
                current = current.RightChild;
            }
            else
            {
                return new BinarySearchTree<T>(current);
            }
        }

        return null;
    }

    private void Range(Node node, Queue<T> queue, T start, T end) 
    {
        if (node == null)
        {
            return;
        }

        int compareLower = node.Value.CompareTo(start);
        int compareHigher = node.Value.CompareTo(end);

        if (compareLower > 0)
        {
            this.Range(node.LeftChild, queue, start, end);
        }

        if (compareLower >= 0 && compareHigher <= 0)
        {
            queue.Enqueue(node.Value);
        }

        if (compareHigher < 0)
        {
            this.Range(node.RightChild, queue, start, end);
        }
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void EachInOrder(Node node, Action<T> action) 
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.LeftChild, action);
        action(node.Value);
        this.EachInOrder(node.RightChild, action);
    }

    public void EachInOrder(Action<T> action)
    {
        Node current = this.root;

        this.EachInOrder(current, action);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Insert(5);
        bst.Insert(3);
        bst.Insert(4);
        bst.Insert(6);
        bst.Insert(8);
        bst.Insert(1);

        var range = bst.Range(2, 7);

        bst.EachInOrder(Console.WriteLine);
    }
}
