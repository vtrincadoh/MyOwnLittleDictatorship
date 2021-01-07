using System.Collections;
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
    //private bool winConditionMeet = false; //Meet the win condition
    //private bool lostConditionMeet = false; //Meet the loss condition
    public GameObject[] minister; //Group of ministers in game
    private int donePatriotic, doneHumanista, doneEconomic; //Contador proyectos aprobados
    public Text aPatriotic, aHumanist, aEconomic; //Contador visual para los proyectos
    public Image FinalVeredict; //Final aproval of proyect


    [Range(0.0f, 10.0f)] public int victoryPointsVal;
    public Slider victoryPoints;
    [Range(0.0f, 10.0f)] public int ResourcePointsVal;
    public Slider ResourcePoints;
    public int MaxPoints;

    public Button attackButton; //Button For attack

    public GameObject AlineationChart; //For changing ministers
    private GameObject usingChart;
    private bool notChanged;
    public Canvas OverlayCanvas;


    //Tv canvas
    public GameObject resultPhases,votingResult,enemyAction;

    public GameObject AlineationChartGameObject;

    public GameObject pauseMenu;
    private C_PauseMenuManager c_pause;

    // Start is called before the first frame update
    void Start()
    {
        notChanged = false;
        generator = gameObject.GetComponent<C_GenProject>();
        voting = gameObject.GetComponent<C_Vote>();
        minister = GameObject.FindGameObjectsWithTag("Minister");
        doneEconomic = doneHumanista = donePatriotic = 0;
        victoryPoints.maxValue = MaxPoints;
        c_pause = pauseMenu.GetComponent<C_PauseMenuManager>();
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

    private void EnableUtilities()
    {
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Utilities")) x.GetComponent<Button>().interactable = true;
    }

    private void DisableUtilities()
    {
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("Utilities")) x.GetComponent<Button>().interactable = false;
    }


    private void EndGame(string Condition) //Manages the game end
    {
        endScreen.SetActive(true);
        endScreen.GetComponent<C_PauseMenuManager>().ChangeText(Condition);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1f)
            {
                Debug.Log("pause");
                c_pause.PauseGame();
            }
            else if (Time.timeScale == 0f)
            {
                Debug.Log("continue");
                c_pause.ContinueGame();
            }
        }
        victoryPoints.value += victoryPointsVal;
        if (checkWinCondition())
        {
            Debug.Log("You win");
            EndGame("You win");
        }
        else if (checkLostCondition())
        {
            Debug.Log("You lost");
            EndGame("You lost");
        }
        else if (!proyectsGenerated)
        {
            phase1();
            ChangeBool();
        }
        //CheckSanity();
    }

    public void phase1()
    {
        AlineationChartGameObject.SetActive(false);
        Debug.Log(string.Format("Actually you have {0} economic, {1} humanist and {2} patriotic proyects approved", doneEconomic, doneHumanista, donePatriotic));
        DisableMinisterButtons();
        attackButton.interactable = false;
        //Generate proyects
        Debug.Log("Generating");
        generator.EnableButtons();
        generator.GenerateProject();
        DisableUtilities();
    }

    public void phase2(GameObject button)
    {
        resultPhases.SetActive(true);
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
        resultPhases.SetActive(true);
        //Review results
        Debug.Log("Reviewing");
        EnableUtilities();
        EnableMinisterButtons();
        if(voting.canAttack) attackButton.interactable = true;
        else attackButton.interactable = false;
        //Get dominant type and compare with proyect type
        Invoke("Transicion1_1", 0.2f);

    }

    void Transicion1_1()
    {
        resultPhases.SetActive(false);
        Invoke("Transicion1_2", 0.2f);
        
    }
    void Transicion1_2()
    {
        votingResult.SetActive(true);
    }

    public void phase4(GameObject m)
    {
        Debug.Log(m.name + " pressed");
        //Change or Adoctrinate
        //Debug.Log("Changing");
        if(m.name == "Skip")
        {
            Debug.Log("Skipped vote");
            DisableMinisterButtons();
            Invoke("ChangeBool", 1f);
        }
        else if(m.name == "attack")
        {
            Debug.Log("Trying to attack");
            if (victoryPoints.value != 0 && voting.canAttack) attackFuction();
            voting.canAttack = false;
            DisableMinisterButtons();
            Invoke("ChangeBool", 1f);
        }
        else if(m.tag == "Minister")
        {
            if (voting.canChooseMinisterType)
            {
                //usingChart = Instantiate(AlineationChart);
                AlineationChartGameObject.SetActive(true);
                DisableMinisterButtons();
                AlineationChartGameObject.GetComponent<C_AlineationChart>().Minister = m;
                //AlineationChartGameObject.GetComponent<C_AlineationChart>().ministerGameObject = m.GetComponent<C_Minister>().minister3dGameObject;
                voting.canChooseMinisterType = false;
                /*
                if (chart.gameObject == null)
                {
                    Debug.Log("Is destroyed");
                    voting.canChooseMinisterType = false;
                    Invoke("ChangeBool", 1f);
                } 
                */
                //Player chooses type
            }
            else
            {
                m.GetComponent<C_Minister>().GenerateChar();
                DisableMinisterButtons();
                Invoke("Transicion2_1", 0.2f);
            }
        }
    }
    public void Transicion2_1()
    {
        votingResult.SetActive(false);
        Invoke("Transicion2_2", 1f);
    }

    void Transicion2_2()
    {
        enemyAction.SetActive(true);
        Invoke("ChangeBool", 1f);
    }


    bool checkWinCondition()
    {
        //Check if win condition meet
        bool flag = false;
        if (victoryPointsVal == MaxPoints && victoryPointsVal >= enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal + 2) flag = true;
        return flag;
    }

    bool checkLostCondition()
    {
        bool flag = false;
        if (enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal >= MaxPoints && victoryPointsVal + 2 <= enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal) flag = true;
        return flag;
    }

    void attackFuction()
    {
        enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal--;
        Mathf.Clamp(enemy.GetComponent<C_EnemyBehavior>().enemyVictoryPointsVal,0,10);
        victoryPoints.value -= 1;
        ResourcePoints.value -= 1;
        Debug.Log("Attacking");
    }

    public void ChangeBool()
    {
        enemy.EnemyTurn();
        proyectsGenerated = !proyectsGenerated;
    }
}
