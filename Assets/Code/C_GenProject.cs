using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Tipos;
using System;

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
        foreach(GameObject b in bProject)
        {
            b.SetActive(false);
        }
    }

    public void EnableButtons()
    {
        foreach (GameObject b in bProject)
        {
            b.SetActive(true);
        }
    }

    public void GenerateProject() //Instanciar el Prefab con alineación
    {
        alineacion domType = DominantType;
        var choosableTypes = Enum
    .GetValues(typeof(alineacion))
    .Cast<alineacion>()
    .Where(item => item != domType)
    .ToArray();
        /*
        GameObject newProject = Instantiate(prefabProject);
        newProject.GetComponent<C_Project>().projectAl = choosableTypes[(int)UnityEngine.Random.value];
        */
        //New form
        foreach(GameObject button in bProject)
        {
            button.GetComponent<C_Project>().projectName = SetName();
            button.GetComponent<C_Project>().projectAl = choosableTypes[(int)UnityEngine.Random.value];
        }
    }

    private string SetName()
    {
        string b = building[UnityEngine.Random.Range(0, building.Count)];
        string bN = buldingName[UnityEngine.Random.Range(0, buldingName.Count)];
        string constructionName = string.Format("{0} of {1}", b, bN);
        //Debug.Log(constructionName);
        return (constructionName);
        //For tipe, it could be recieve setname(Alineacion) and having diferent list of names for each alineacion
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
