using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;
using Puestos;

public class C_Minister : MonoBehaviour
{ 
    public string ministerName;
    private List<string> names = new List<string>(new string[] { "Eduardo", "Jeremy", "Abdul", "Joseph", "Jonathan" });
    private List<string> surNames = new List<string>(new string[] { "Gray", "Joestart", "Habidin", "Espfer", "A" });
    [SerializeField] private Tipos.alineacion myAlineacion;
    public Puestos.puestos myPuesto;

    private void Start()
    {
        SetName();
        setAlination();
    }

    private void SetName()
    {
        //GenerateRandomName with ministerName
        string name = names[Random.Range(0, names.Count)];
        string surName = surNames[Random.Range(0, surNames.Count)];
        ministerName = string.Format("{0} {1}",name, surName);
    }

    private void setAlination()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                myAlineacion = alineacion.Economico;
                break;
            case 1:
                myAlineacion = alineacion.Humanista;
                break;
            case 2:
                myAlineacion = alineacion.Patriota;
                break;
            default:
                myAlineacion = alineacion.standart;
                break;
        }
    }

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
