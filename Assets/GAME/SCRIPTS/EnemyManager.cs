using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 newPos = Vector3.zero;
            newPos.x = Random.Range(-5, 6);
            newPos.y = Random.Range(-5, 6);

            Instantiate(enemyPrefab, newPos, Quaternion.identity, this.transform);

            Destroy(this.gameObject);
            
        }
    }
}
