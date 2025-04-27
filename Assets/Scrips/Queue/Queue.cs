using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue<T> 
{
    private QueueNode<T> head = null;
    private QueueNode<T> last = null;

    private int count = 0;

    public QueueNode<T> Head => head;
    public QueueNode<T> Last => last;
    public int Count => count;

    public virtual void Enqueue(T item)
    {
        QueueNode<T> newNode = new QueueNode<T>(item);
        count++;

        if (last == null && head == null)
        {
            head = newNode;
            last = newNode;
            return;
        }
        newNode.SetNext(last);
        last = newNode;
    }
    public virtual T Dequeue()
    {
        if (count <= 0 || head == null)
        {
            count = 0;
            return default;
        }

        T valueToReturn = head.Value;

        head = GetNextFromLast();
        count--;

        if (count == 0)
        {
            head = null;
            last = null;
        }

        return valueToReturn;
    }
    public virtual T Peek()
    {
        if (head == null)
            return default;
        return head.Value;
    }
    public virtual void Clear()
    {
        head = null;
        last = null;
        count = 0;
    }

    private QueueNode<T> GetNextFromLast()
    {
        QueueNode<T> current = last;

        for (int i = 0; i < count - 1; i++)
        {
            current = current.Next;
        }

        return current;
    }

    public void ReadQueue(QueueNode<T> _current = null, int depth = 0)
    {
        if (depth >= count)
            return;
        if (_current == null)
        {
            _current = last;
        }
        if (_current == null)
        {
            Debug.Log("Lista Completa ");
            return;
        }

        Debug.Log("Nodo en posicion " + (count - depth) + "De valor :" + _current.Value.ToString());
        ReadQueue(_current.Next, depth + 1);
    }
}
