using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveController : MonoBehaviour
{
    [SerializeField] BeeController beePrefab;
    [SerializeField] int beeCount = 3;

    public void SpawBee(Transform playerTransform)      // Spawn bees at random positions around the hive
    {
        for (int i = 0; i < beeCount; i++)
        {
            Vector3 spawnPosition = this.transform.position +  new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            BeeController bee = Instantiate(beePrefab, spawnPosition, Quaternion.identity);
            bee.transform.SetParent(this.transform);
            bee.Init(playerTransform);
        }
    }
}
