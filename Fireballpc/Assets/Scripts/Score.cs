using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0;

    public int difficultyLevel = 1;
    public int maxDifficultyLevel = 20;
    private int scoreToNextLevel = 20;

    public Text scoreText;
    private bool isDead = false;
    public DeathMenu deathMenu;


    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += 2*(Time.deltaTime) * difficultyLevel;
        scoreText.text = ((int)score).ToString();
    }

    public void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<FireballMovement>().SetSpeed(difficultyLevel);
        Debug.Log(difficultyLevel);
     
    }
    public void OnDeath()
    {
        isDead = true;
        if(PlayerPrefs.GetFloat("Highscore")< score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }      
        deathMenu.ToggleEndMenu(score);
    }
}
