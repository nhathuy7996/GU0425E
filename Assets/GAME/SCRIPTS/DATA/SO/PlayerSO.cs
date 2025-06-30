using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataSO", menuName = "Data/Player")]
public class PlayerSO : ScriptableObject
{
    public float speed = 10;
    public float jumpForce = 600;
}
