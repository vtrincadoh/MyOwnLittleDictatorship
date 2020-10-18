using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;
using Puestos;
using UnityEngine.UI;

public class C_Minister : MonoBehaviour
{ 
    public string ministerName;
    private List<string> names = new List<string>(new string[] { "Eduardo", "Jeremy", "Abdul", "Joseph", "Jonathan" });
    private List<string> surNames = new List<string>(new string[] { "Gray", "Joestart", "Habidin", "Espfer", "A" });
    public Tipos.alineacion myAlineacion;
    public Puestos.puestos myPuesto;
    public float sanity,rateOfSanityRecovery, rateOfSanityLost;

    private void Start()
    {
        SetName();
        setAlination();
        sanity = Random.Range(30.5f, 55f);
    }

    private void SetName()
    {
        //GenerateRandomName with ministerName
        string name = names[Random.Range(0, names.Count)];
        string surName = surNames[Random.Range(0, surNames.Count)];
        ministerName = string.Format("{0} {1}",name, surName);
    }

    private void Update()
    {
        sanity += rateOfSanityRecovery * Time.deltaTime;
        sanity = Mathf.Clamp(sanity, 0f, 100f);
    }

    private void setAlination()
    {
        int i = Random.Range(0, 2);
        switch (i)
        {
            case 0:
                myAlineacion = alineacion.Economico;
                gameObject.GetComponent<Image>().color = Color.green;
                break;
            case 1:
                myAlineacion = alineacion.Humanista;
                gameObject.GetComponent<Image>().color = Color.blue;
                break;
            case 2:
                myAlineacion = alineacion.Patriota;
                gameObject.GetComponent<Image>().color = Color.red;
                break;
            default:
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
        Debug.LogFormat("Minister {0} with {1} alination voted {2}", ministerName, myAlineacion, descision);
        if (descision) sanity -= rateOfSanityLost;
        return descision;
    }

    private bool RandomBool()
    {
        return (Random.value > 0.5f);
    }
}
