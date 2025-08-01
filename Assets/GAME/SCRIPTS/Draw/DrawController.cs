using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;

    Rigidbody2D rb;
    [SerializeField]
    List<Vector3> poins = new List<Vector3>();
    List<Vector2> edgePoints = new List<Vector2>();
    Vector3? lastPoint = null;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        this.lineRenderer = GetComponent<LineRenderer>();
        this.edgeCollider = GetComponent<EdgeCollider2D>();

        this.edgeCollider.edgeRadius = this.lineRenderer.startWidth;
        this.rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.rb.simulated = true;
        }

        if (!Input.GetMouseButton(0))
        {
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (this.lastPoint == null || Vector3.Distance(mousePos, this.lastPoint.Value) > 0.5f)
        {
            this.lastPoint = mousePos;
            this.poins.Add(new Vector3(mousePos.x, mousePos.y, 0));
            this.edgePoints.Add(new Vector2(mousePos.x, mousePos.y));

            this.lineRenderer.positionCount = this.poins.Count;
            this.lineRenderer.SetPositions(this.poins.ToArray());
      
            this.edgeCollider.SetPoints(edgePoints);
        }
       
    }
}
