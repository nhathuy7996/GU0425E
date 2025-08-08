using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    
    [SerializeField]
    PLAYER_STATE _playerState = PLAYER_STATE.IsIdle;
    [SerializeField] bool _isShoot = false;
    public bool IsShoot => _isShoot;

    [SerializeField] IGun _gunController;


    public PLAYER_STATE PlayerState => _playerState;
    [SerializeField]
    AnimController anim;

    [SerializeField] PlayerSO playerDataSO;

    Rigidbody2D rigidbody2D;
    [SerializeField] InputActionReference jumpAction, attackAction, movementAction;

    [SerializeField] float rayGroundDistance = 2f;
    [SerializeField] bool _isGrounded = false;

    Collider2D _Collider;
 
    protected override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.anim = this.GetComponentInChildren<AnimController>();
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this._gunController = this.GetComponentInChildren<IGun>(); 
        this._Collider = this.GetComponent<Collider2D>();
    }

    void Update()
    {
        this._isGrounded = this.IsGrounded2();
        
        this.AutoDetectState();
        float face = this.transform.localScale.x;
        if (movementAction.action.ReadValue<Vector2>().x != 0)
        {
            face = movementAction.action.ReadValue<Vector2>().x > 0 ? 1 : -1;
        }

        this.transform.localScale = new Vector3(face, 1, 1);

        if (jumpAction.action.WasPressedThisFrame() && this._isGrounded)
            this.rigidbody2D.AddForce(Vector2.up * this.playerDataSO.jumpForce);

        if (attackAction.action.IsPressed())
        {
            this._gunController.Fire(face);
            
        }
        
        this._isShoot = attackAction.action.IsPressed();
    }

    void FixedUpdate()
    {
        Vector2 movement = this.rigidbody2D.velocity;
        movement.x = movementAction.action.ReadValue<Vector2>().x * this.playerDataSO.speed;
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

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, rayGroundDistance);
        Debug.DrawRay(this.transform.position, Vector2.down * rayGroundDistance, Color.red);
        if (hit == null || hit.collider == null)
        {
            this.transform.parent = null;
            return false;
        }

        this.transform.parent = hit.transform;
        return true;
    }

    public bool IsGrounded2()
    {
        RaycastHit2D[] hits = new RaycastHit2D[10];
        this._Collider.Cast(Vector2.down, hits, rayGroundDistance);
        foreach (var hit in hits)
        {
            if (hit != null && hit.collider != null)
            {
                this.transform.parent = hit.transform;
                return true;
            }
        }
        
        this.transform.parent = null;
        return false;
    }

    public enum PLAYER_STATE
    {
        IsIdle = 0,
        IsRun = 1,
        IsJump = 2
    }
}
