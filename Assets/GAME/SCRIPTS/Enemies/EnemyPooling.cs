using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : Singleton<EnemyPooling>
{
    [SerializeField] CreepCtrl creepCtrlPrefab;
    List<CreepCtrl> creeps = new List<CreepCtrl>();

    public CreepCtrl GetCreep()
    {
        foreach (var item in creeps)
        {
            if (item.gameObject.activeSelf)
                continue;
            return item;
        }

        CreepCtrl c = Instantiate(creepCtrlPrefab, this.transform);
        this.creeps.Add(c);
        c.gameObject.SetActive(false);

        return c;

    }
}
