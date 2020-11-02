using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tipos;
using UnityEngine.UI;

public class C_Vote : MonoBehaviour
{
    public Object[] ministerOnLevel;
    private int yes, no; //Cuántos dijeron que sí y cuántos que no
    public Image FinalVeredict;

    // Start is called before the first frame update
    void Start()
    {
        ministerOnLevel = GameObject.FindGameObjectsWithTag("Minister");
    }

    public void InvokeVoting(GameObject proyect)
    {
        FinalVeredict.color = Color.gray;
        Tipos.alineacion al = proyect.GetComponent<C_Project>().projectAl;
        results(al);
        if (yes > no)
        {
            FinalVeredict.color = Color.green;
            Debug.Log("Se Aprueba");
        } //Hacer do while
        else if (yes < no)
        {
            FinalVeredict.color = Color.red;
            Debug.Log("Se Rechaza");
        }
        else //Si hay empate se repite la votacion
        {
            results(al);
            if (yes > no){
                FinalVeredict.color = Color.green;
                Debug.Log("Se Aprueba");
            }
            else {
                FinalVeredict.color = Color.red;
                Debug.Log("Se Rechaza");
            }
        }
        yes = 0;
        no = 0;
        Invoke("ResetColor", 3f);
    }

    public void ResetColor()
    {
        FinalVeredict.color = Color.gray;
    }

    void results(Tipos.alineacion alin) //cuenta de votos
    {
        yes = no = 0;
        foreach (GameObject minister in ministerOnLevel)
        {
            if (minister.GetComponent<C_Minister>().AskVote(alin)) yes++;
            else no++;
        }
    }
}
