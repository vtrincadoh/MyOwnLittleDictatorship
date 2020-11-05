﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_Phase : MonoBehaviour
{
    public C_GenProject generator; //Script for generating proyects
    public C_Vote voting; //Script for voting
    public C_EnemyBehavior enemy; //Script from enemy
    public GameObject endScreen; //Shows when you win/lost
    private bool proyectsGenerated = false; //Started new generated proyects
    private bool winConditionMeet = false; //Meet the win condition
    private bool lostConditionMeet = false; //Meet the loss condition
    public GameObject[] minister; //Group of ministers in game
    private int donePatriotic, doneHumanista, doneEconomic; //Contador proyectos aprobados
    public Text aPatriotic, aHumanist, aEconomic; //Contador visual para los proyectos
    public Image FinalVeredict; //Final aproval of proyect


    [Range(0.0f, 10.0f)] public int victoryPointsVal;
    public Slider victoryPoints;
    [Range(0.0f, 10.0f)] public int ResourcePointsVal;
    public Slider ResourcePoints;

    public Button attackButton;

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
        victoryPoints.value += victoryPointsVal;
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
        attackButton.interactable = false;
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
        attackButton.interactable = true;
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
        else if(m.name == "attack")
        {
            if (victoryPoints.value != 0) attackFuction();
            DisableMinisterButtons();
            Invoke("ChangeBool", 2f);
        }
        else
        {
            if (voting.canChooseMinisterType)
            {
                //Player chooses type
                Debug.Log("Choosing type");
                
                if (Input.GetKey("a")) {
                    Debug.Log("Pressed a");
                    m.GetComponent<C_Minister>().myAlineacion = alineacion.Economico;
                    voting.canChooseMinisterType = false;
                }
                else if (Input.GetKey(KeyCode.B)) {
                    Debug.Log("Pressed b");
                    m.GetComponent<C_Minister>().myAlineacion = alineacion.Patriota;
                    voting.canChooseMinisterType = false;
                }
                else if (Input.GetKey(KeyCode.C)){
                    Debug.Log("Pressed c");
                    m.GetComponent<C_Minister>().myAlineacion = alineacion.Humanista;
                    voting.canChooseMinisterType = false;
                }
                if (!voting.canChooseMinisterType)
                {
                    Debug.Log("Final type is " + m.GetComponent<C_Minister>().myAlineacion);
                    DisableMinisterButtons();
                    Invoke("ChangeBool", 1f);
                }
            }
            else
            {
                m.GetComponent<C_Minister>().GenerateChar();
                DisableMinisterButtons();
                Invoke("ChangeBool", 1f);
            }
        }
        if (victoryPoints.value == 10) winConditionMeet = true;
    }

    void attackFuction()
    {
        enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal--;
        Mathf.Clamp(enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal,0,10);
        ResourcePoints.value -= 1;
        Debug.Log("Attacking");
    }

    void ChangeBool()
    {
        enemy.EnemyTurn();
        proyectsGenerated = !proyectsGenerated;
    }
}
