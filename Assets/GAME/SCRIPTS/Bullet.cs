using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D rigi;

    void Start()
    {
        this.rigi = this.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigi.velocity = this.transform.right * _speed;
    }

    void OTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject); 
    }
}
