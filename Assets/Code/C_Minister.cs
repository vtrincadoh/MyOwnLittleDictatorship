using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Minister : MonoBehaviour
{
    public enum alineacion
    {
        Economico,Humanista,Patriota
    }

    public string ministerName;
    public alineacion myAlineacion;

    public int AskVote(alineacion alineacionProyecto)
    {
        int desicion = 0; // 0 = rechazo y 1 = apruebo
        if(alineacionProyecto.GetType() == myAlineacion.GetType())
        {
            desicion = 1;
        }
        else
        {
            desicion = Random.Range(0, 1);
        }
        Debug.LogFormat("Minister {0} voted {1}", ministerName, desicion);
        return desicion;
    }
}
