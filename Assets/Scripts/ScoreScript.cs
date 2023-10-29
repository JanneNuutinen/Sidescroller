using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private float score;
    public float point = 1f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            score += point * Time.fixedDeltaTime;
            scoreText.text = "Score: " + ((int)score).ToString();
        }
           
    }
}
