using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreepCtrl : MonoBehaviour, IHitable
{
    [SerializeField] float _HP = 100;
    float maxHP = 100;
    Vector2? _target = null;
    [SerializeField] float _speed = 1;
    [SerializeField] float _attackRange = 10;

    [SerializeField] Slider _hpBar;
    public void Init(float speed, Slider slider)
    {
        this._hpBar = slider;
        this._speed = speed;
        ResetTarget();
        this._HP = Random.Range(50, 100);
        this.maxHP = this._HP;
        this._hpBar.maxValue = this.maxHP;
        this._hpBar.value = this._HP;
        this._hpBar.gameObject.SetActive(true);
    }

    void Update()
    {
        _hpBar.transform.position = this.transform.position + Vector3.up * 0.65f;
        this.DetectPlayer();
        if (_target == null ||  Vector2.Distance((Vector2)_target, this.transform.position) < 0.5f)
        {
            ResetTarget();
        }

        Vector2 dir = (Vector2)_target - (Vector2)this.transform.position;
        dir = dir.normalized;

        this.transform.Translate(dir * _speed * Time.deltaTime);
    }

    void DetectPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, _attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<PlayerController>() == null)
                continue;
            this._target = collider.transform.position;
            return;
        }

        if (this._target == null)
            this.ResetTarget();
        
    }

    void ResetTarget()
    {
        this._target = new Vector2(Random.Range(-5, 6), Random.Range(3, 6));
        
    }


    public void GetHit(float dmg)
    {

        // this._gameManager.AddScore();
        this._HP -= dmg;
        this._hpBar.value = this._HP;
        if (this._HP <= 0)
        {
            ObserverManager.Notify(ObserverKey.addScore, this.maxHP / 100 * 10);
            this.gameObject.SetActive(false);
            this._hpBar.gameObject.SetActive(false);
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, _attackRange); 
    }
}
