﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Tipos;
using System;
using UnityEngine.UI;

public class C_GenProject : MonoBehaviour
{
    private List<string> building = new List<string>(new string[] { "Hospital", "Banco", "Parque", "Estadio", "Edificio" }); //Tipo de construccion (Se podria separar por tipo)
    private List<string> buldingName = new List<string>(new string[] { "El sabio", "Gran nacion", "Altisimo", "Genial", "Superbio" }); //Nombre de la contruccion

    GameObject[] _ministerOnLevel; //Arreglo con ministros
    Dictionary<alineacion, int> _nType = new Dictionary<alineacion, int> { //Cantidad de ministros por tipo
        {alineacion.Economico, 0},
        {alineacion.Humanista, 0},
        {alineacion.Patriota, 0},
    };
    public GameObject prefabProject; //Prefab de objeto con C_Project como componente

    GameObject[] bProject; //Arreglo de botones

    private void Start() //Get groups of project buttons
    {
        bProject = GameObject.FindGameObjectsWithTag("Proyect");
    }

    public void DisableButtons()
    {
        //Disable button
        foreach(GameObject b in bProject)
        {
            b.SetActive(false);
        }
    }

    public void EnableButtons()
    {
        //Enable button
        foreach (GameObject b in bProject)
        {
            b.SetActive(true);
        }
    }

    public void GenerateProject() //Instanciar el Prefab con alineación
    {
        alineacion domType = DominantType;
        alineacion[] ListaAElegir = new alineacion[bProject.Count()];
        int cantDom = 0;
        for(int x = 0; x < bProject.Count(); x++)
        {
            alineacion adding = (alineacion)UnityEngine.Random.Range(0, 3);
            if(adding == domType)
            {
                if(cantDom >= 1)
                {
                    do
                    {
                        adding = (alineacion)UnityEngine.Random.Range(0, 3);
                    } while (adding == domType);
                }
                cantDom++;
            }
            ListaAElegir[x] = adding;
        }
        foreach(var i in ListaAElegir)
        {
            Debug.Log("There is " + i);
        }
        int a = 0;
        foreach(GameObject button in bProject)
        {
            button.GetComponent<C_Project>().projectName = SetName();
            button.GetComponent<C_Project>().projectAl = ListaAElegir[a];
            a++;
            switch (button.GetComponent<C_Project>().projectAl)
            {
                //Asign color to proyect button
                case alineacion.Economico:
                    button.GetComponent<Image>().color = Color.green;
                    break;
                case alineacion.Humanista:
                    button.GetComponent<Image>().color =  Color.blue;
                    break;
                case alineacion.Patriota:
                    button.GetComponent<Image>().color = Color.red;
                    break;
                default:
                    button.GetComponent<Image>().color = Color.black;
                    break;
            }
            if(DominantType == button.GetComponent<C_Project>().projectAl){
                //Block button of dominant type
                button.GetComponent<Image>().color = Color.black;
                button.GetComponent<Button>().interactable = false;
            }
            else button.GetComponent<Button>().interactable = true;
        }
    }

    private string SetName()
    {
        //Generate contruction name
        string b = building[UnityEngine.Random.Range(0, building.Count)];
        string bN = buldingName[UnityEngine.Random.Range(0, buldingName.Count)];
        string constructionName = string.Format("{0} of {1}", b, bN);
        return (constructionName);
    }

    public alineacion DominantType //Alineación mayor de la mesa
    {
        get
        {
            foreach (GameObject minister in GameObject.FindGameObjectsWithTag("Minister"))
            {
                _nType[minister.GetComponent<C_Minister>().myAlineacion]++;
            }
            alineacion _keyOfMaxValue = _nType.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return _keyOfMaxValue;
        }
    }
}