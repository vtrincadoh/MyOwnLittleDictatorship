using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_AlineationChart : MonoBehaviour
{
    public GameObject Minister;
    public GameObject ministerGameObject;
    private GameObject self;
    public GameObject self3d;
    public C_Phase phase;

    private void Start()
    {
        phase = GameObject.FindGameObjectWithTag("Player").GetComponent<C_Phase>();
        self = this.gameObject;
        Debug.Log("Self is " + self.name);
    }

    private void Update()
    {
        self3d.transform.position = ministerGameObject.transform.position + Vector3.up * 1.5f;
        self3d.transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public void Change(Button type)
    {
        switch (type.name)
        {
            case "BPatriota":
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Patriota;
                Minister.GetComponent<Image>().color = Color.red;
                Debug.Log("Cambiado a Patriora");
                phase.ChangeBool();
                Destroy(self);
                break;
            case "BHumanista":
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Humanista;
                Minister.GetComponent<Image>().color = Color.blue;
                Debug.Log("Cambiado a Humanista");
                phase.ChangeBool();
                Destroy(self);
                break;
            case "BEconomico":
                Minister.GetComponent<C_Minister>().myAlineacion = alineacion.Economico;
                Minister.GetComponent<Image>().color = Color.green;
                Debug.Log("Cambiado a Economico");
                phase.ChangeBool();
                Destroy(self);
                break;
            default:
                break;
        }
    }
}
