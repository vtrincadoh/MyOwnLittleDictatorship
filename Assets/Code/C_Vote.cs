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

    public Slider victorySlider; //Slider for victory and resources points
    public Slider resourcesSlider;

    public bool canChooseMinisterType,canAttack;

    public Image canvasVote;
    public Text canvasText;

    // Start is called before the first frame update
    void Start()
    {
        ministerOnLevel = GameObject.FindGameObjectsWithTag("Minister");
        canChooseMinisterType = false;
    }

    public void InvokeVoting(GameObject proyect)
    {
        FinalVeredict.color = Color.gray;
        Tipos.alineacion al = proyect.GetComponent<C_Project>().projectAl;
        results(al);
        if (yes > no)
        {
            FinalVeredict.color = Color.green;
            canvasVote.color = Color.green;
            canvasText.text = "Se aprueba";
            Debug.Log("Se Aprueba");
            PointTypeManager(al);
        } //Hacer do while
        else if (yes < no)
        {
            FinalVeredict.color = Color.red;
            canvasVote.color = Color.red;
            canvasText.text = "Se rechaza";
            Debug.Log("Se Rechaza");
        }
        else //Si hay empate se repite la votacion
        {
            results(al);
            if (yes > no){
                FinalVeredict.color = Color.green;
                canvasVote.color = Color.green;
                canvasText.text = "Se aprueba";
                Debug.Log("Se Aprueba");
                PointTypeManager(al);
            }
            else {
                canvasVote.color = Color.red;
                FinalVeredict.color = Color.red;
                canvasText.text = "Se rechaza";
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

    public void PointTypeManager(Tipos.alineacion alin)
    {
        Debug.Log("Reviewing type");
        switch (alin)
        {
            case alineacion.Economico:
                resourcesSlider.value += 1;
                Debug.Log("Resources increased");
                break;
            case alineacion.Humanista:
                //Elige alineacion ministro
                canChooseMinisterType = true;
                Debug.Log("Can choose minister type");
                break;
            case alineacion.Patriota:
                victorySlider.value += 1;
                canAttack = true;
                Debug.Log("Victory Increased");
                break;
            default:
                break;
        }
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
