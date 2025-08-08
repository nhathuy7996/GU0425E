using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyPooling : Singleton<LazyPooling>
{
    Dictionary<GameObject, List<GameObject>> pools = new Dictionary<GameObject, List<GameObject>>();

     Dictionary<Behaviour, List<Behaviour>> pools2 = new Dictionary<Behaviour, List<Behaviour>>();

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

    public T getObjType<T>(T prefab) where T: Behaviour 
    {
         if (!pools2.ContainsKey(prefab))
            this.pools2.Add(prefab, new List<Behaviour>());

        foreach (var item in this.pools2[prefab])
        {
          
            if (item.gameObject.activeSelf)
                continue;
            return (T)item;
        }

        T g = Instantiate(prefab, this.transform);
        this.pools2[prefab].Add(g);
        g.gameObject.SetActive(false);

        return g;
    }
}
