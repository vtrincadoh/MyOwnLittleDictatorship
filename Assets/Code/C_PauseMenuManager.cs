﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C_PauseMenuManager : MonoBehaviour
{
    public Text finalText;

    private void PauseGame() //Pause Game
    {
        Time.timeScale = 0f;
    }

    public void Reload() //Restard game
    {
        SceneManager.LoadScene(1);
    }

    public void Return() // Return to main screen
    {
        SceneManager.LoadScene(0);
    }
    
    public void ChangeText(string state) //Change depending if you win/lost, called when game ends
    {
        PauseGame();
        finalText.text = state;
    }
}
