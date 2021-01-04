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

    public Text actionGained;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyResourcesPoints.value = enemyResourcesPointsVal = 0;
        enemyResourcesPoints.value = enemyResourcesPointsVal = 0;
    }

    public void EnemyTurn()
    {
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
                        actionGained.text = "Enemy attacked you";
                        player.GetComponent<C_Phase>().victoryPointsVal--;
                    }
                    else
                    {
                        if(Random.Range(0, 1) == 0)
                        {
                            actionGained.text = "Enemy gained victory points";
                            Debug.Log("Enemy took victory points");
                            enemyVictoryPointsVal++;
                        }
                        else
                        {
                            actionGained.text = "Enemy gained resources points";
                            Debug.Log("Enemy took resources points");
                            enemyResourcesPointsVal++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        Invoke("cleanText", 0.5f);
    }

    void cleanText()
    {
        actionGained.text = "";
    }
}
