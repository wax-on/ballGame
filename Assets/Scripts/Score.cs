using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public int highScore;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore");
    }

    // check if you got a new high score if so set new high score
    void Update()
    {
        scoreUI.text = score.ToString();
        highScoreUI.text = highScore.ToString();
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if you collide with tags get points score ++
        if (other.gameObject.tag == "scoreup")
        {
            score++;
        };
        if (other.gameObject.tag == "coin")
        {
            score++;
        };
    }
}
