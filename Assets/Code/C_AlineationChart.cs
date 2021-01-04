using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_AlineationChart : MonoBehaviour
{
    public GameObject Minister;
    public GameObject typePlacement;
    private GameObject self;
    //public GameObject self3d;
    public C_Phase phase;
    public Button patriot, humanist, econ;

    private void Start()
    {
        //typePlacement = GameObject.Find("Type");
        phase = GameObject.FindGameObjectWithTag("Player").GetComponent<C_Phase>();
        //self3d.transform.SetParent(null);
        self = this.gameObject;
        //self3d.transform.position = typePlacement.transform.position;
        //self3d.transform.rotation = Quaternion.Euler(new Vector3(15, 0, 0));
        Debug.Log("Self is " + self.name);
        Debug.Log(Minister.GetComponent<C_Minister>().ministerName + "Changing ");
        //Debug.Log(Minister.GetComponent<C_Minister>().ministerName + "Changing ");
    }

    public void Change(Button type)
    {
        
        switch (type.name)
        {
            case "Patriota":
                //self3d.transform.SetParent(this.gameObject.transform);
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Patriota;
                Minister.GetComponent<Image>().color = Color.red;
                Debug.Log("Cambiado a Patriora");
                //phase.ChangeBool();
                //Destroy(self, 0.2f);
                Invoke("Changebool", 0.2f);
                break;
            case "Humanista":
                //self3d.transform.SetParent(this.gameObject.transform);
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Humanista;
                Minister.GetComponent<Image>().color = Color.blue;
                Debug.Log("Cambiado a Humanista");
                //phase.ChangeBool();
                //Destroy(self, 0.2f);
                Invoke("Changebool", 0.2f);
                break;
            case "Econmocio":
                //self3d.transform.SetParent(this.gameObject.transform);
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Economico;
                Minister.GetComponent<Image>().color = Color.green;
                Debug.Log("Cambiado a Economico");
                //phase.ChangeBool();
                //Destroy(self,0.2f);
                Invoke("Changebool", 0.2f);
                break;
            default:
                break;
        }
    }

    private void Changebool()
    {
        phase.Transicion2_1();
        self.SetActive(false);
    }
}
