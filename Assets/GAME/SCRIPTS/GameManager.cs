using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instant;

    public static GameManager Instant => _instant;

    [SerializeField]
    int _score = 0;

    public int Score => _score;

    void Awake()
    {
        var gms = FindObjectsOfType<GameManager>();
        if (gms.Length > 1 && _instant != null && _instant.GetInstanceID() != this.GetInstanceID())
        {
            Destroy(this.gameObject);
            return;
        }
        _instant = this;
    }

    public void AddScore(int scr = 1)
    {
        this._score += scr;
    }

    public void ResetScore()
    {
        this._score = 0;
    }
}
