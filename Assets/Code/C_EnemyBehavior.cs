using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_EnemyBehavior : MonoBehaviour
{
    //public Slider enemyVictoryPoints,enemyResourcesPoints;
    public int enemyVictoryPointsVal, enemyResourcesPointsVal;
    public int AproovedOrRejectedPointRange;

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
                    if(enemyVictoryPointsVal > 0)
                    {
                        //attack
                    }
                    else
                    {
                        if(Random.Range(0, 1) == 0)
                        {
                            Debug.Log("Enemy took victory points");
                            enemyVictoryPointsVal++;
                        }
                        else
                        {
                            Debug.Log("Enemy took resources points");
                            enemyResourcesPointsVal++;
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
