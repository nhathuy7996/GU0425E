using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : Singleton<BulletPooling>
{
    [SerializeField] Bullet _bulletPrefab;

    List<Bullet> _bullets = new List<Bullet>();

    public Bullet getBullet()
    {
        foreach (var item in _bullets)
        {
            if (item.gameObject.activeSelf)
                continue;
            return item;
        }

        Bullet b = Instantiate(this._bulletPrefab, this.transform);
        b.gameObject.SetActive(false);
        _bullets.Add(b);

        return b;
    }
}
