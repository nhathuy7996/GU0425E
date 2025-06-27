using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCtrl : MonoBehaviour
{
    GameManager _gameManager;
    public void Init(GameManager gm)
    {
        this._gameManager = gm;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Bullet>(out var bullet))
        {
            return;
        }

        Destroy(bullet.gameObject);
        Destroy(this.gameObject);

        this._gameManager.AddScore();
         
    }

}
