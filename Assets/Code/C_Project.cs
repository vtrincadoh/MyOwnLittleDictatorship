using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tipos;

public class C_Project : MonoBehaviour
{
    public Text namePlace;
    public GameObject objectSame;

    private void Update()
    {
        namePlace.text = projectName;
    }

    public enum alineacion
    {
        Economico, Humanista, Patriota
    }

    public string projectName;
    public Tipos.alineacion projectAl;
}
