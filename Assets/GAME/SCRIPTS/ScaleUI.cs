using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUI : MonoBehaviour
{
    [SerializeField] Vector2 scaleStart, scaleEnd;
    [SerializeField] float duration = 1f;

    RectTransform rectTransform;


    void Start()
    {
        this.rectTransform = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        this.rectTransform.localScale = Vector2.Lerp(scaleStart, scaleEnd, Mathf.PingPong(Time.time / duration, 1));
    }
}
