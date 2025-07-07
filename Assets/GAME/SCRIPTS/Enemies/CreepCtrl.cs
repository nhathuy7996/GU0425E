using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCtrl : MonoBehaviour, IHitable
{
    [SerializeField] float _HP = 100;
    float maxHP = 100;
    Vector2 _target;
    [SerializeField] float _speed = 1;
    public void Init(float speed)
    {
        this._speed = speed;
        ResetTarget();
        this._HP = Random.Range(50, 100);
        this.maxHP = this._HP;
    }

    void Update()
    {
        if (Vector2.Distance(_target, this.transform.position) < 0.5f)
        {
            ResetTarget();
        }

        Vector2 dir = _target - (Vector2)this.transform.position;
        dir = dir.normalized;

        this.transform.Translate(dir * _speed * Time.deltaTime);
    }

    void ResetTarget()
    {
        this._target = Vector2.zero;
        this._target .x = Random.Range(-5, 6);
        this._target .y = Random.Range(3, 6);
    }


    public void GetHit(float dmg)
    {
        
        // this._gameManager.AddScore();
        this._HP -= dmg;
        if (this._HP <= 0)
        {
            ObserverManager.Notify(ObserverKey.addScore, this.maxHP / 100 * 10);
            this.gameObject.SetActive(false);
        }
       
    }
}
