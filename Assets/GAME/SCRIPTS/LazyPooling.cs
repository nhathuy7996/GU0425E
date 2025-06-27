using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyPooling : Singleton<LazyPooling>
{
    Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

    public GameObject getObject(GameObject prefab)
    {
        if (!pools.ContainsKey(prefab))
            this.pools.Add(prefab, new List<GameObject>());

        foreach (var item in this.pools[prefab])
        {
            Debug.Log($"{item.name} -- {item.activeSelf}");
            if (item.activeSelf)
                continue;
            return item;
        }

        GameObject g = Instantiate(prefab, this.transform);
        this.pools[prefab].Add(g);
        g.SetActive(false);

        return g;
    }

    public T getObjType<T>(T prefab) where T: MonoBehaviour
    {
        return this.getObject(prefab.gameObject).GetComponent<T>();
    }
}
