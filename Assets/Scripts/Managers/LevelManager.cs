﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public ScoreScript scoreScript;
    public PlayerScript player;
    public EnemyScript enemy;
    public Enemy2Script enemy2;
    public CloudScript cloud01;
    public CloudScript cloud02;
    public CloudScript cloud03;
    public CloudScript cloud04;
    public GroundScript ground;
    public GameObject pauseScreen;
    public GameObject endingScreen;
    public int maxScore;
    public bool playingLevel = true;
    public bool lvlEnded = false;
    public bool pause = false;

	void Start ()
    {
        //PlayerPrefs.SetInt("maxScore", maxScore);
        //scoreScript.UpdateScore(maxScore);
    }

    void Update ()
    {
        //scoreScript.UpdateScore(maxScore);
        cloud01.PlayingLevel(playingLevel);
        cloud02.PlayingLevel(playingLevel);
        cloud03.PlayingLevel(playingLevel);
        cloud04.PlayingLevel(playingLevel);

        ground.PlayingLevel(playingLevel);

        if (playingLevel)
        {
            pauseScreen.SetActive(false);
            endingScreen.SetActive(false);
            player.gameObject.SetActive(true);
            enemy.gameObject.SetActive(true);
        }

        if (lvlEnded)
        {
            enemy.Reset();
            enemy2.Reset();
            ground.Reset();
            endingScreen.SetActive(true);
            player.gameObject.SetActive(false);
            enemy.gameObject.SetActive(false);
            //scoreScript.maxScore = PlayerPrefs.GetInt("maxScore", maxScore);
        }

        if (pause)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
	}

    public void StartLevel()
    {
        scoreScript.Reset();
        player.life = 1;
        playingLevel = true;
        lvlEnded = false;
        pause = false;
    }

    public void FinishLevel()
    {
        playingLevel = false;
        lvlEnded = true;
    }

    public void Pause()
    {
        pause = !pause;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}