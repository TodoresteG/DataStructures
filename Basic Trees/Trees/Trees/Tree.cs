using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>(children);
    }

    public T Value { get; private set; }

    public List<Tree<T>> Children { get; private set; }

    public void Print(int indent = 0)
    {
        Console.Write(new string(' ', 2 * indent));
        Console.WriteLine(this.Value);

        foreach (var node in this.Children)
        {
            node.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var node in this.Children)
        {
            node.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> node, List<T> result) 
    {
        foreach (var child in node.Children)
        {
            this.DFS(child, result);
        }

        result.Add(node.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> result = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> currentNode = queue.Dequeue();

            foreach (var child in currentNode.Children)
            {
                queue.Enqueue(child);
            }

            result.Add(currentNode.Value);
        }

        return result;
    }
}
