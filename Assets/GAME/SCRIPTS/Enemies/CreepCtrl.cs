using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepCtrl : MonoBehaviour
{
    GameManager _gameManager;
    Vector2 _target;
    [SerializeField] float _speed = 1;
    public void Init(GameManager gm, float speed)
    {
        this._gameManager = gm;
        this._speed = speed;
        ResetTarget();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Bullet>(out var bullet))
        {
            return;
        }

        bullet.gameObject.gameObject.SetActive(false);
        Destroy(this.gameObject);

        // this._gameManager.AddScore();
        GameManager.Instant.AddScore();
    }

}
