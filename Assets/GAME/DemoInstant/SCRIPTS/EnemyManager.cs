using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DemoInstant
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] Queue<GameObject> _enemies = new Queue<GameObject>();
        public Queue<GameObject> Enemies => _enemies;

        [SerializeField] GameObject _enemyPrefab;
        int count = 3;
        // Start is called before the first frame update
        void Start()
        {
            this.count = this.transform.childCount;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this._enemies.Enqueue(this.transform.GetChild(i).gameObject);
            }
        }

        public void SpawEnemy()
        {
            Vector3 newPos = Vector3.zero;
            newPos.x = Random.Range(-5, 6);
            newPos.y = Random.Range(-5, 6);

            GameObject newE = Instantiate(_enemyPrefab, newPos, Quaternion.identity, this.transform);
            this._enemies.Enqueue(newE);

            this.count++;
            newE.name += this.count;
        } 
    }
}
