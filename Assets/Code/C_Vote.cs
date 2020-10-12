using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;

public class C_Vote : MonoBehaviour
{
    public Object[] ministerOnLevel;
    private int yes, no; //Cuántos dijeron que sí y cuántos que no

    // Start is called before the first frame update
    void Start()
    {
        ministerOnLevel = GameObject.FindGameObjectsWithTag("Minister");
    }

    void InvokeVoting(GameObject proyect)
    {
        Tipos.alineacion al = proyect.GetComponent<C_Project>().projectAl;
        results(al);
        if(yes > no) Debug.Log("Se Aprueba");
        else if (yes < no) Debug.Log("Se Rechaza");
        else //Si hay empate se repite la votacion
        {
            results(al);
            if (yes > no) Debug.Log("Se Aprueba");
            else Debug.Log("Se Rechaza");
        }
    }

    void results(Tipos.alineacion alin) //cuenta de votos
    {
        yes = no = 0;
        foreach (GameObject minister in ministerOnLevel)
        {
            if (minister.GetComponent<C_Minister>().AskVote(alin)) yes++;
            else no++;
        }
    }
}
