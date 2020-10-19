using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_Phase : MonoBehaviour
{
    public C_GenProject generator; //Script for generating proyects
    public C_Vote voting; //Script for voting
    private bool proyectsGenerated = false; //Started new generated proyects
    private bool winConditionMeet = false; //Meet the win condition
    private bool lostConditionMeet = false; //Meet the loss condition
    public GameObject[] minister; //Group of ministers in game

    // Start is called before the first frame update
    void Start()
    {
        generator = gameObject.GetComponent<C_GenProject>();
        voting = gameObject.GetComponent<C_Vote>();
        minister = GameObject.FindGameObjectsWithTag("Minister");
    }

    private void CheckSanity() //Check if everybody is insane or theres still insanity in ministers
    {
        bool everyBodyInsane = false;
        foreach (GameObject m in minister)
        {
            if (m.GetComponent<C_Minister>().sanity < 100f) everyBodyInsane = true;
        }
        if (!everyBodyInsane) lostConditionMeet = true;
    }

    private void EnableMinisterButtons()
    {
        foreach(GameObject x in minister)
        {
            x.GetComponent<Button>().interactable = true;
        }
    }

    private void DisableMinisterButtons()
    {
        foreach (GameObject x in minister)
        {
            x.GetComponent<Button>().interactable = false;
        }
    }

    private void Update()
    {
        if (winConditionMeet)
        {
            Debug.Log("You win");
            Application.Quit();
        }
        else if (lostConditionMeet)
        {
            Debug.Log("You lost");
            Application.Quit();
        }
        else if (!proyectsGenerated)
        {
            phase1();
            ChangeBool();
        }
        CheckSanity();
    }

    public void phase1()
    {
        DisableMinisterButtons();
        //Generate proyects
        Debug.Log("Generating");
        generator.EnableButtons();
        generator.GenerateProject();
    }

    public void phase2(GameObject button)
    {
        //Voting phase
        Debug.Log("Voting");
        voting.InvokeVoting(button);
        generator.DisableButtons();
        Invoke("phase3",5f);
    }

    public void phase3()
    {
        //Review results
        Debug.Log("Reviewing");
        EnableMinisterButtons();
        //Get dominant type and compare with proyect type
    }

    public void phase4(GameObject m)
    {
        //Change or Adoctrinate
        //Debug.Log("Changing");
        if(m.name == "Skip")
        {
            Debug.Log("Skipped vote");
        }
        else
        {
            //Debug.Log("Changing minister " + m.name);
            m.GetComponent<C_Minister>().GenerateChar();
            //Debug.Log("Now is " + m.GetComponent<C_Minister>().ministerName + " of " + m.GetComponent<C_Minister>().myAlineacion);
        }
        DisableMinisterButtons();
        Invoke("ChangeBool", 5f);
    }

    void ChangeBool()
    {
        proyectsGenerated = !proyectsGenerated;
    }
}
