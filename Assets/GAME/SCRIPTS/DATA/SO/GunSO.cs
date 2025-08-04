using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunDataSO", menuName = "Data/Gun")]
public class GunSO : ScriptableObject
{
    public float bulletSpeed;
    public float dmg;

    public float fireSpeed;
    public Bullet bulletPrefab;

    public AudioClip gunSoundClip;
}
