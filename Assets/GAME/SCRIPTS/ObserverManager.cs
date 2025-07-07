using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ObserverKey
{
    public static readonly string addScore = "addScore";
    public static readonly string loadPlayerData = "loadData";
    public static readonly string savePlayerData = "saveData";
}

public static class ObserverManager
{
    static Dictionary<string, List<Action<object[]>>> _actions = new Dictionary<string, List<Action<object[]>>>();

    public static void AddListener(string key, Action<object[]> callback)
    {
        if (!_actions.ContainsKey(key))
            _actions.Add(key, new List<Action<object[]>>());

        _actions[key].Add(callback);
    }

    public static void RemoveListener(string key, Action<object[]> callback)
    {
        if (!_actions.ContainsKey(key))
            return;

        _actions[key].Remove(callback);
    }

    public static void Notify(string key, params object[] datas)
    {
        if (!_actions.ContainsKey(key))
            return;
        foreach (var item in _actions[key])
            item?.Invoke(datas);
    }
}
