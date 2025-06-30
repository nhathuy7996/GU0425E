using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] Transform _fireSpot;
    [SerializeField] GunSO gunDataSO;

    float timer = 0;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Fire(float face)
    {
        if (timer < this.gunDataSO.fireSpeed)
            return;
        timer = 0;
        Quaternion q = this.gunDataSO.bulletPrefab.transform.rotation;
        q.eulerAngles = new Vector3(0, 0, face == -1 ? 180 : 0);

        //Instantiate(this._bulletPrefab, this._fireSpot.position, q);

        // Bullet b = BulletPooling.Instant.getBullet();
        // b.transform.rotation = q;
        // b.transform.position = this._fireSpot.position;
        // b.gameObject.SetActive(true);

        Bullet b = LazyPooling.Instant.getObjType(this.gunDataSO.bulletPrefab);
        b.transform.rotation = q;
        b.transform.position = this._fireSpot.position;
        b.Init(this.gunDataSO.bulletSpeed, this.gunDataSO.dmg);

        b.gameObject.SetActive(true);
    }
}
