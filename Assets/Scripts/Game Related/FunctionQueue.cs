using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionQueue : MonoBehaviour
{
    private Queue<System.Func<IEnumerator>> coroutineQueue = new Queue<System.Func<IEnumerator>>();
    private Queue<System.Action> functionQueue = new Queue<System.Action>();

    // Add a function to the queue
    public void Enqueue(System.Action function)
    {
        functionQueue.Enqueue(function);
    }

    // Add a coroutine function to the queue
    public void EnqueueCoroutine(System.Func<IEnumerator> coroutineFunction)
    {
        coroutineQueue.Enqueue(coroutineFunction);
    }

    // Execute functions and coroutine functions in the queue
    public void ExecuteQueue()
    {
        StartCoroutine(ExecuteCoroutineQueue());
    }

    private IEnumerator ExecuteCoroutineQueue()
    {
        while (coroutineQueue.Count > 0 || functionQueue.Count > 0)
        {
            if (coroutineQueue.Count > 0)
            {
                System.Func<IEnumerator> nextCoroutineFunction = coroutineQueue.Dequeue();
                yield return StartCoroutine(nextCoroutineFunction());
            }
            else if (functionQueue.Count > 0)
            {
                System.Action nextFunction = functionQueue.Dequeue();
                nextFunction.Invoke();
            }
        }
    }
}
