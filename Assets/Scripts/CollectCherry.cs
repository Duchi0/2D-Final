using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollectCherry : MonoBehaviour
{
    private ScoreManager scoreManager;
    private void Start()
    {
        GameObject scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            scoreManager.incrementScore(10);
            Destroy(collision.gameObject);
        }
    }
}
