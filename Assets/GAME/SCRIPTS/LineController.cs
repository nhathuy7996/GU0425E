using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LineController : MonoBehaviour
{
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);
      
        if (hit == null || hit.collider == null)
        {
            lineRenderer.SetPosition(1,  transform.up * 1000);
            
            return;
        }
        Debug.LogError(hit.collider.gameObject.name);
       lineRenderer.SetPosition(1, hit.point);
    }
}
