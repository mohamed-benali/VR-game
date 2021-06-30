using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public int score;

    // Patron Singleton (variable global a todos), accesibe desde culquier sitio
    public static ScoreManager scoreInstance;
    public static ScoreManager getScoreInstance()
    {
        return scoreInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreInstance = this;
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increase_score()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}
