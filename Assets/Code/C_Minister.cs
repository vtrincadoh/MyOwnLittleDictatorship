using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;

public class C_Minister : MonoBehaviour
{ 
    public string ministerName;
    public Tipos.alineacion myAlineacion;

    public bool AskVote(Tipos.alineacion alineacionProyecto)
    {
        bool descision; 
        if(alineacionProyecto.GetType() == myAlineacion.GetType())
        {
            descision = true;
        }
        else
        {
            descision =  RandomBool();
        }
        Debug.LogFormat("Minister {0} voted {1}", myAlineacion, descision);
        return descision;
    }

    private bool RandomBool()
    {
        return (Random.value > 0.5f);
    }
}
