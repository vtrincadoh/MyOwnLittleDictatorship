using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;
using Puestos;

public class C_Minister : MonoBehaviour
{ 
    public string ministerName;
    public Tipos.alineacion myAlineacion;
    public Puestos.puestos myPuesto;

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
