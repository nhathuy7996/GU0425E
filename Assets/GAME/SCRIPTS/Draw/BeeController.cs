using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Transform target)
    {
        this.target = target;
       
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (target == null)
            return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed * Time.deltaTime;
        Debug.LogError($"Bee moving towards {direction * speed * Time.deltaTime}");
    }
}
