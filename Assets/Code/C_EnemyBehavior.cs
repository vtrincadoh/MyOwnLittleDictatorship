using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EnemyBehavior : MonoBehaviour
{
    public Slider enemyVictoryPoints,enemyResourcesPoints;
    public int enemyVictoryPointsVal, enemyResourcesPointsVal;
    public int AproovedOrRejectedPointRange;

    public GameObject player;

    public GameObject points, enemyAction; 

    public Text actionGained;

    void Enableenemy()
    {
        enemyAction.SetActive(true);
    }

    void DisableEnemy()
    {
        enemyAction.SetActive(false);
        Invoke("Transicion1_1", 0.2f);
    }

    private void Awake()
    {
        actionGained.GetComponent<Text>().text = "";
        enemyVictoryPoints.value = enemyVictoryPointsVal = 0;
        enemyResourcesPoints.value = enemyResourcesPointsVal = 0;
        //DisableEnemy();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyVictoryPoints.value = enemyVictoryPointsVal;
        enemyResourcesPoints.value = enemyResourcesPointsVal;
        Mathf.Clamp(enemyVictoryPoints.value, 0, 6);
        Mathf.Clamp(enemyResourcesPoints.value, 0, 10);
    }

    public void EnemyTurn()
    {
        Enableenemy();
        int getsPoint = Random.Range(0, 100);
        if(getsPoint >= AproovedOrRejectedPointRange)
        {
            Debug.Log("Enemy earned a point");
            switch (Random.Range(0,2))
            {
                case 0: //To victory points
                    Debug.Log("Enemy took victory points");
                    enemyVictoryPointsVal++;
                    break;
                case 1: //To Resources points
                    Debug.Log("Enemy took resources points");
                    enemyResourcesPointsVal++;
                    break;
                case 2: //Enemy attack player
                    if(enemyVictoryPointsVal != 0 && enemyResourcesPointsVal != 0)
                    {
                        actionGained.GetComponent<Text>().text = "Enemy attacked you";
                        player.GetComponent<C_Phase>().victoryPointsVal--;
                    }
                    else
                    {
                        if(Random.Range(0, 1) == 0)
                        {
                            actionGained.GetComponent<Text>().text = "Enemy gained victory points";
                            Debug.Log("Enemy took victory points");
                            enemyVictoryPointsVal++;
                        }
                        else
                        {
                            actionGained.GetComponent<Text>().text = "Enemy gained resources points";
                            Debug.Log("Enemy took resources points");
                            enemyResourcesPointsVal++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        else actionGained.GetComponent<Text>().text = "Enemy failed to aproved a project";
        Invoke("cleanText", 0.8f);
    }

    void cleanText()
    {
        Invoke("DisableEnemy", 0.2f);
    }
    
    void Transicion1_1()
    {
        points.SetActive(true);
    }
}
