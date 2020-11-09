using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_3DRelatedButton : MonoBehaviour
{
    public Button thisButton;
    public bool canBeInteracted;

    private void Update()
    {
        canBeInteracted = thisButton.GetComponent<Button>().interactable;
        if (thisButton.GetComponent<Image>() != null) gameObject.GetComponent<MeshRenderer>().material.color = thisButton.GetComponent<Image>().color; //Could glow
    }

    public void Selected()
    {
        Debug.Log("Selected");
        if (canBeInteracted) thisButton.onClick.Invoke();
    }
}
