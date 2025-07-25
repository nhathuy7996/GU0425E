using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class LoopingBG : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    [SerializeField] float _widthImage;
   
   Camera _camera;
    // The speed at which the background loops
    // Start is called before the first frame update
    void Start()
    {
        this._camera = Camera.main;
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        Texture image = this._spriteRenderer.sprite.texture;
        this._widthImage = image.width / this._spriteRenderer.sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(this._camera.transform.position.x - this.transform.position.x) > this._widthImage)
        {
            Vector3 pos = this.transform.position;
            pos.x = this._camera.transform.position.x;

            this.transform.position = pos;
        }
    }
}
