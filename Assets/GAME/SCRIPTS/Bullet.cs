using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody2D rigi;

    Coroutine coroutineDisable;

    void Start()
    {
        this.rigi = this.GetComponent<Rigidbody2D>();
         
    }

    public void Init(float speed, float dmg)
    {
        this._speed = speed;
        //this.dmg = dmg;
    }

    void OnEnable()
    {
        this.coroutineDisable = StartCoroutine(Deactive());
    }

    void OnDisable()
    {
        if (this.coroutineDisable != null)
            StopCoroutine(this.coroutineDisable);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigi.velocity = this.transform.right * _speed;
    }

    IEnumerator Deactive()
    {
        yield return new WaitForSeconds(10);
        this.gameObject.SetActive(false); 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        if (collision.TryGetComponent<IHitable>(out var isCanHit))
        {
            isCanHit.GetHit(0);
        }
    }
}
