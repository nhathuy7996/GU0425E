using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleGunController : MonoBehaviour, IGun
{
    [SerializeField] Transform _fireSpot;
    [SerializeField] GunSO gunDataSO;
    
     float timer = 0;
     void Update()
    {
        timer += Time.deltaTime;
    }

    void Start()
    {
        this.gunDataSO = Resources.Load<GunSO>("GunDataSO"); 
    }

    public void Fire(float face)
    {
        if (timer < this.gunDataSO.fireSpeed)
            return;
        timer = 0;
        Quaternion q = this.gunDataSO.bulletPrefab.transform.rotation;
        q.eulerAngles = new Vector3(0, 0, face == -1 ? 180 : 0);

        Bullet b = LazyPooling.Instant.getObjType(this.gunDataSO.bulletPrefab);
        b.transform.rotation = q;
        b.transform.position = this._fireSpot.position;
        b.Init(this.gunDataSO.bulletSpeed, this.gunDataSO.dmg);

        b.gameObject.SetActive(true);


        q.eulerAngles = new Vector3(0, 0, face == -1 ? 160 : -20);

        b = LazyPooling.Instant.getObjType(this.gunDataSO.bulletPrefab);
        b.transform.rotation = q;
        b.transform.position = this._fireSpot.position;
        b.Init(this.gunDataSO.bulletSpeed, this.gunDataSO.dmg);

        b.gameObject.SetActive(true);

        q.eulerAngles = new Vector3(0, 0, face == -1 ? 210 : 20);

        b = LazyPooling.Instant.getObjType(this.gunDataSO.bulletPrefab);
        b.transform.rotation = q;
        b.transform.position = this._fireSpot.position;
        b.Init(this.gunDataSO.bulletSpeed, this.gunDataSO.dmg);

        b.gameObject.SetActive(true);
    }
}
