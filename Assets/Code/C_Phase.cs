using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_Phase : MonoBehaviour
{
    public C_GenProject generator; //Script for generating proyects
    public C_Vote voting; //Script for voting
    public GameObject endScreen; //Shows when you win/lost
    private bool proyectsGenerated = false; //Started new generated proyects
    private bool winConditionMeet = false; //Meet the win condition
    private bool lostConditionMeet = false; //Meet the loss condition
    public GameObject[] minister; //Group of ministers in game
    private int donePatriotic, doneHumanista, doneEconomic; //Contador proyectos aprobados
    public Text aPatriotic, aHumanist, aEconomic; //Contador visual para los proyectos
    public Image FinalVeredict; //Final aproval of proyect


    [Range(0.0f, 10.0f)] public float victoryPointsVal;
    public Slider victoryPoints;

    // Start is called before the first frame update
    void Start()
    {
        generator = gameObject.GetComponent<C_GenProject>();
        voting = gameObject.GetComponent<C_Vote>();
        minister = GameObject.FindGameObjectsWithTag("Minister");
        doneEconomic = doneHumanista = donePatriotic = 0;
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

    private void EndGame(string Condition) //Manages the game end
    {
        endScreen.SetActive(true);
        endScreen.GetComponent<C_PauseMenuManager>().ChangeText(Condition);
    }

    private void Update()
    {
        victoryPoints.value = victoryPointsVal;
        if (winConditionMeet)
        {
            Debug.Log("You win");
            EndGame("You win");
        }
        else if (lostConditionMeet)
        {
            Debug.Log("You lost");
            EndGame("You lost");
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
        Debug.Log(string.Format("Actually you have {0} economic, {1} humanist and {2} patriotic proyects approved", doneEconomic, doneHumanista, donePatriotic));
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
        if(FinalVeredict.color == Color.green)
        {
            alineacion align = button.GetComponent<C_Project>().projectAl;
            switch (align)
            {
                case alineacion.Economico:
                    doneEconomic++;
                    break;
                case alineacion.Humanista:
                    doneHumanista++;
                    break;
                case alineacion.Patriota:
                    donePatriotic++;
                    break;
            }
        }
        //Asignando valores para visualizar
        aPatriotic.text = donePatriotic.ToString();
        aEconomic.text = doneEconomic.ToString();
        aHumanist.text = doneHumanista.ToString();

        generator.DisableButtons();
        Invoke("phase3", 1f);
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
        Invoke("ChangeBool", 1f);
        if (doneEconomic >= 2 && doneHumanista >= 2 && donePatriotic >= 2) winConditionMeet = true;
    }

    void ChangeBool()
    {
        proyectsGenerated = !proyectsGenerated;
    }
}
