using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class C_PauseMenuManager : MonoBehaviour
{
    public Text finalText;
    private Scene sc;

    private void Start()
    {
        sc = SceneManager.GetActiveScene();
    }

    private void PauseGame() //Pause Game
    {
        Time.timeScale = 0f;
    }

    public void Reload() //Restard game
    {
        Application.LoadLevel(sc.name);
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
