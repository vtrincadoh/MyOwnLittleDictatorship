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

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
