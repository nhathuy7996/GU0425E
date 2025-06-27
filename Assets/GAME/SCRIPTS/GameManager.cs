using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
 

    [SerializeField]
    int _score = 0;

    public int Score => _score;
 

    public void AddScore(int scr = 1)
    {
        this._score += scr;
    }

    public void ResetScore()
    {
        this._score = 0;
    }
}
