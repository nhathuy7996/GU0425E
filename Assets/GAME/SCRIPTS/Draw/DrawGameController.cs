using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGameController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] HiveController hiveController;

    void Start()
    {
        ObserverManager.AddListener(ObserverKey.DrawEnd, OnDrawEnd);
    }

    private void OnDrawEnd(object[] obj)
    {
        hiveController.SpawBee(player); 
    }

 

}
