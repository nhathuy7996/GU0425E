using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace DemoInstant
{
    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rigi;
        [SerializeField] float _speed = 1;
        [SerializeField] EnemyManager _enemyManager;

        GameObject _target;

        void Start()
        {
            rigi = this.GetComponent<Rigidbody2D>();
            this._target = this._enemyManager.Enemies.Dequeue();
        }

        // Update is called once per frame
        void Update()
        {

            while (this._target == null)
            {
                this._target = this._enemyManager.Enemies.Dequeue();
                this._enemyManager.SpawEnemy();
            }


            Vector2 dir = (this._target.transform.position - this.transform.position).normalized;
            this.rigi.velocity = dir * _speed;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject == null);
            Debug.Log(this._target == null);
        }
    }
}
