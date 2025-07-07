using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTest : MonoBehaviour
{
    // delegate float NoParam(int i);

    // NoParam callback;

    // Predicate<int> callback;

    Func<int, float> callback;

    void Start()
    {
        this.callback += testing;
        this.callback -= testing;

        this.callback?.Invoke(0);
    }


    float testing(int i)
    {
        Debug.Log("Test delegate");
        return 0;
    }
}
