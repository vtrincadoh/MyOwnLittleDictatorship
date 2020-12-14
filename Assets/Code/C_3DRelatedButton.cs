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
        if(thisButton.tag != "Minister")
        {
            if(thisButton.interactable || thisButton.GetComponent<Image>().color != Color.black) this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            else this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void Selected()
    {
        Debug.Log("Selected button " + thisButton.name);

        if (canBeInteracted) thisButton.onClick.Invoke();
    }
}
