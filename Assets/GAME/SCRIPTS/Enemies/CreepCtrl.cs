using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreepCtrl : MonoBehaviour, IHitable
{
    [SerializeField] float _HP = 100;
    float maxHP = 100;
    Vector2? _target = null;
    [SerializeField] float _speed = 1;
    public float Speed => _speed;
    [SerializeField] float _attackRange = 10;

    [SerializeField] Slider _hpBar;

    [SerializeField] LayerMask _layerMask;

    CreepStateBase currentCreepState;

    Dictionary<Type, CreepStateBase> allState = new Dictionary<Type, CreepStateBase>();

    void Awake()
    {
        
        allState.Add(typeof(CreepStatePatrol), new CreepStatePatrol(this) );
        allState.Add(typeof(CreepStateChase), new CreepStateChase(this));
    }

    public void Init(float speed, Slider slider)
    {
        this._hpBar = slider;
        this._speed = speed;
       
        this._HP = Random.Range(50, 100);
        this.maxHP = this._HP;
        this._hpBar.maxValue = this.maxHP;
        this._hpBar.value = this._HP;
        this._hpBar.gameObject.SetActive(true); 
        this.ChangeState(typeof(CreepStatePatrol));
    }

    public void ChangeState(Type newState)
    {

        if (!allState.ContainsKey(newState))
            return;

        if (this.currentCreepState == this.allState[newState])
                return;

        if(this.currentCreepState != null)
            this.currentCreepState.OnExit();
        this.currentCreepState = this.allState[newState];
        this.currentCreepState.OnEnter();
    }

    void Update()
    {
        currentCreepState?.Execute();
        _hpBar.transform.position = this.transform.position + Vector3.up * 0.65f;
        
    }

    public Transform DetectPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, _attackRange);
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<PlayerController>() == null)
                continue;

            return collider.transform;
        }

        return null;
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
