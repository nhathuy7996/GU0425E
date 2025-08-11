using System;

public class ActionNode<T> : INode<T>
{
    public string DebugName => typeof(T).Name;

    private readonly Action<T> _action;

    public ActionNode(Action<T> action)
    {
        _action = action ?? throw new ArgumentNullException(nameof(action));
    }

    public void Tick(T context)
    {
        this._action?.Invoke(context);
    }

}
