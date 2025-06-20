using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] Transform _fireSpot;
    [SerializeField] GameObject _bulletPrefab;


    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Fire(float face)
    {
        if (timer < 1)
            return;
        timer = 0;
        Quaternion q = this._bulletPrefab.transform.rotation;
        q.eulerAngles = new Vector3(0,0,face == -1? 180:0);
        Instantiate(this._bulletPrefab,this._fireSpot.position,q);
    }
}
