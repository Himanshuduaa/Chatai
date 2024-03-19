using System.Collections;
using UnityEngine;

public class FunctionsManager : MonoBehaviour
{
    private FunctionQueue functionQueue;

    private void Start()
    {
        //// Initialize the FunctionQueue
        //functionQueue = GetComponent<FunctionQueue>();
        //if (functionQueue == null)
        //{
        //    Debug.LogError("FunctionQueue component not found on GameObject.");
        //    return;
        //}

        //// Enqueue some functions and coroutine functions
        //functionQueue.Enqueue(CustomFunction1);
        //functionQueue.EnqueueCoroutine(CoroutineFunction1);
        //functionQueue.Enqueue(CustomFunction2);
        //functionQueue.EnqueueCoroutine(CoroutineFunction2);

        //// Execute the queue
        //functionQueue.ExecuteQueue();
    }

    private void CustomFunction1()
    {
        Debug.Log("Custom Function 1 executed");
    }

    private void CustomFunction2()
    {
        Debug.Log("Custom Function 2 executed");
    }

    private IEnumerator CoroutineFunction1()
    {
        Debug.Log("Coroutine Function 1 started");
        yield return new WaitForSeconds(2);
        Debug.Log("Coroutine Function 1 ended");
    }

    private IEnumerator CoroutineFunction2()
    {
        Debug.Log("Coroutine Function 2 started");
        yield return new WaitForSeconds(3);
        Debug.Log("Coroutine Function 2 ended");
    }
}
