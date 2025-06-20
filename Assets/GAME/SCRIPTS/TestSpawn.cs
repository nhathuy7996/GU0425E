using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject e = new GameObject("Enemy");
        e.AddComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
