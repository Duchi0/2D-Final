using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score { get; private set; } = 0;

    private void Start()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
    }
    public void incrementScore(int increment = 1)
    {
        score += increment;
    }
}
