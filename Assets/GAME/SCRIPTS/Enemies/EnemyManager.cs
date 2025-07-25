using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float _enemySpeed = 2;
    [SerializeField] CreepCtrl enemyPrefab;
    [SerializeField] GameManager _gameManager;
    [SerializeField] Slider _hpBarPrefab;
    [SerializeField] Transform _canvasHPBar;


    void Start()
    {
        //InvokeRepeating("SpawnEnemy",5,4);

        StartCoroutine(SpawnEnemyRepeat());
    }

    // float timer = 0, maxTimeSpawn = 5;
    // // Update is called once per frame
    // void Update()
    // {
    //     timer += Time.deltaTime;
    //     if (timer > maxTimeSpawn)
    //     {
    //         SpawnEnemy();
    //         maxTimeSpawn = Random.Range(3,5);
    //         timer = 0;
    //     }
    // }

    IEnumerator SpawnEnemyRepeat()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3,5));
            SpawnEnemy();
 
        }
       
    }

    void SpawnEnemy()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = Random.Range(-5, 6);
        newPos.y = Random.Range(3, 6);

        // CreepCtrl c = EnemyPooling.Instant.GetCreep();
        // c.transform.position = newPos;
        // c.gameObject.SetActive(true);
        // c.Init(this._gameManager, _enemySpeed);

        var hpBar = LazyPooling.Instant.getObjType(this._hpBarPrefab);
        hpBar.transform.SetParent(this._canvasHPBar);
        hpBar.transform.localScale = Vector3.one;
        

        CreepCtrl c = LazyPooling.Instant.getObjType(this.enemyPrefab);
        c.transform.position = newPos;
        c.Init(_enemySpeed, hpBar);
        c.gameObject.SetActive(true);
        

            
       // Invoke("SpawnEnemy",Random.Range(3,5));
    }
}
