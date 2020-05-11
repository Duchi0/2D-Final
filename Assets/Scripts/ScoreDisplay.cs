using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private ScoreManager scoreManager;

    private void Start()
    {
        GameObject scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }
    private void Update()
    {
        scoreText.text = $"Score: {scoreManager.score}";
    }
}
