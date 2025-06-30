using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    
    [SerializeField]
    PLAYER_STATE _playerState = PLAYER_STATE.IsIdle;
    [SerializeField] bool _isShoot = false;
    public bool IsShoot => _isShoot;

    [SerializeField] GunController _gunController;


    public PLAYER_STATE PlayerState => _playerState;
    [SerializeField]
    AnimController anim;

    [SerializeField] PlayerSO playerDataSO;

    Rigidbody2D rigidbody2D;


    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.anim = this.GetComponentInChildren<AnimController>();
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this._gunController = this.GetComponentInChildren<GunController>(); 
    }

    void Update()
    {
        this.AutoDetectState();
        float face = this.transform.localScale.x;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            face = Input.GetAxisRaw("Horizontal");
        }

        this.transform.localScale = new Vector3(face, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space))
            this.rigidbody2D.AddForce(Vector2.up * this.playerDataSO.jumpForce);

        if (Input.GetKey(KeyCode.C) )
        {
            this._gunController.Fire(face);
        }

  if (Input.GetKey(KeyCode.Z) )
        {
            this.playerDataSO.speed = 20;
        }

        this._isShoot = Input.GetKey(KeyCode.C);

        
    }

    void FixedUpdate()
    {
        Vector2 movement = this.rigidbody2D.velocity;
        movement.x = Input.GetAxisRaw("Horizontal") * this.playerDataSO.speed;
        this.rigidbody2D.velocity = movement;
    }

    void AutoDetectState()
    {
        if (this.rigidbody2D.velocity.y != 0)
        {
            this._playerState = PLAYER_STATE.IsJump;
            return;
        }
        this._playerState = Math.Abs(this.rigidbody2D.velocity.x) > 0.1f ? PLAYER_STATE.IsRun : PLAYER_STATE.IsIdle;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        this.transform.SetParent(collision2D.transform);
    }

     void OnCollisionExit2D(Collision2D collision2D)
    {
        this.transform.SetParent(null);
    }

    public enum PLAYER_STATE
    {
        IsIdle = 0,
        IsRun = 1,
        IsJump = 2
    }
}
