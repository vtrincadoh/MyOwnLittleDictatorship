using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Tipos;
using System;

public class C_GenProject : MonoBehaviour
{
    GameObject[] _ministerOnLevel; //Arreglo con ministros
    Dictionary<alineacion, int> _nType = new Dictionary<alineacion, int> { //Cantidad de ministros por tipo
        {alineacion.Economico, 0},
        {alineacion.Humanista, 0},
        {alineacion.Patriota, 0},
    };
    public GameObject prefabProject; //Prefab de objeto con C_Project como componente

    public void GenerateProject() //Instanciar el Prefab con alineación
    {
        alineacion domType = DominantType;
        var choosableTypes = Enum
    .GetValues(typeof(alineacion))
    .Cast<alineacion>()
    .Where(item => item != domType)
    .ToArray();

        GameObject newProject = Instantiate(prefabProject);
        newProject.GetComponent<C_Project>().projectAl = choosableTypes[(int)UnityEngine.Random.value];
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
