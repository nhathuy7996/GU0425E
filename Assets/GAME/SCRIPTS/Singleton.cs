using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instant;

    public static T Instant
    {
        get
        {
            if (_instant == null)
            {
                GameObject g = new GameObject(typeof(T).ToString());
                _instant = g.AddComponent<T>();
            }
            return _instant;
        }
    }

    protected virtual void Awake()
    {
        var gms = FindObjectsOfType<T>();
        if (gms.Length > 1 && _instant != null && _instant.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(this.gameObject);
            return;
        }
        _instant = this.GetComponent<T>();
    }
}
