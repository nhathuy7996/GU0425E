using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INode<TContext>
{
    void Tick(TContext context);
    string DebugName { get; }
}


