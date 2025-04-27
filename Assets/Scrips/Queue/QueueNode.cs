using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueNode<T>
{
    #region Properties
    private T value;
    private QueueNode<T> next;
    #endregion

    #region Getters
    public T Value => value;
    public QueueNode<T> Next => next;
    #endregion

    #region Constructors
    public QueueNode(T value)
    {
        this.value = value;
        this.next = null;
    }
    public void SetNext(QueueNode<T> _next)
    {
        this.next = _next;
    }

    #endregion
}
