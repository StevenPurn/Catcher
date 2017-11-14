using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameControl {

    public static int targetScore;
    public static int totalScore;
    public static int highScore;
    public static float speed = 175f;
    public static float startSpeed = 175f;
    public static bool gameOver = false;

    public delegate void ChangeScoreDelegate();
    public static ChangeScoreDelegate changeScoreEvent;

    public static void ChangeScore(int change)
    {
        totalScore += change;
        if(totalScore > highScore)
        {
            highScore = totalScore;
        }
        changeScoreEvent();
    }

    public static void IncreaseSpeed()
    {
        speed *= 1.1f;
        if(speed > 350f)
        {
            speed = 350f;
        }
    }

    public static void GameOver()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        gameOver = true;
        speed = 0;
    }

    public static void Reset()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        speed = startSpeed;
        ChangeScore(-totalScore);
        gameOver = false;
    }
}
