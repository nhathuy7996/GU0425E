using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionNode<T> : INode<T>
{
    public string DebugName => throw new System.NotImplementedException();

    private readonly Func<T, bool> _decision;
    private readonly INode<T> _trueNode;
    private readonly INode<T> _falseNode;

    public DecisionNode(Func<T, bool> decision, INode<T> trueNode, INode<T> falseNode)
    {
        _decision = decision ?? throw new ArgumentNullException(nameof(decision));
        _trueNode = trueNode ?? throw new ArgumentNullException(nameof(trueNode));
        _falseNode = falseNode ?? throw new ArgumentNullException(nameof(falseNode));
    }


    public void Tick(T context)
    {
        if (this._decision(context))
        {
            _trueNode.Tick(context);
            return;
        }
         _falseNode.Tick(context);
    }
}
