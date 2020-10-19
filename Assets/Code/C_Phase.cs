using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;

public class C_Phase : MonoBehaviour
{
    public C_GenProject generator; //Script for generating proyects
    public C_Vote voting; //Script for voting
    private bool proyectsGenerated = false; //Started new generated proyects
    private bool winConditionMeet = false; //Meet the win condition
    private bool lostConditionMeet = false; //Meet the loss condition

    // Start is called before the first frame update
    void Start()
    {
        generator = gameObject.GetComponent<C_GenProject>();
        voting = gameObject.GetComponent<C_Vote>();
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
    }

    public void phase1()
    {
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
        //Get dominant type and compare with proyect type
        Invoke("phase4", 5f);
    }

    public void phase4()
    {
        //Change or Adoctrinate
        Debug.Log("Changing");
        Invoke("ChangeBool", 5f); ;
    }

    void ChangeBool()
    {
        proyectsGenerated = !proyectsGenerated;
    }
}
