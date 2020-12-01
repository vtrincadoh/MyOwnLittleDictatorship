using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_MenuManager : MonoBehaviour
{
    //This is a menu
    public void Quit()
    {
        Debug.Log("Quitting aplication");
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(4);
    }

    public void Options()
    {
        SceneManager.LoadScene(3);
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }
    public void Ping()
    {
        Debug.Log("Pong");
    }

}
