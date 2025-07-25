using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingBG : MonoBehaviour
{
    SpriteRenderer[] _spriteRenderers;
    [SerializeField] float[] _widthImage;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D playerRigi;
   
   Camera _camera;
    // The speed at which the background loops
    // Start is called before the first frame update
    void Start()
    {
        this._camera = Camera.main;
        this._spriteRenderers = this.GetComponentsInChildren<SpriteRenderer>();
        _widthImage = new float[this._spriteRenderers.Length];

        for (int i = 0; i < this._spriteRenderers.Length; i++)
        {
            SpriteRenderer spriteRenderer = this._spriteRenderers[i];
            Texture image = spriteRenderer.sprite.texture;
            _widthImage[i] = image.width / spriteRenderer.sprite.pixelsPerUnit;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int way = this.playerRigi.velocity.x == 0 ? 0 : this.playerRigi.velocity.x > 0? -1 : 1;
        // if (this.playerRigi.velocity.x == 0)
        // {
        //     way = 0;
        // }
        // else 
        // {
        //     way = this.playerRigi.velocity.x > 0 ? 1 : -1;
        // }

        for (int i = 0; i < this._spriteRenderers.Length; i++)
        {
            SpriteRenderer spriteRenderer = this._spriteRenderers[i];
            if (Math.Abs(this._camera.transform.position.x - spriteRenderer.transform.position.x) > this._widthImage[i])
            {
                Vector3 pos = spriteRenderer.transform.position;
                pos.x = this._camera.transform.position.x;

                spriteRenderer.transform.position = pos;
            }
            spriteRenderer.transform.Translate(new Vector3(way,0,0) * this._speed * i * Time.deltaTime);
        }

        
    }
}
