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
        if (this.gameObject.tag == "3DProject") AdquireColor();
        canBeInteracted = thisButton.GetComponent<Button>().interactable;
        if (thisButton.GetComponent<Image>() != null) gameObject.GetComponent<MeshRenderer>().material.color = thisButton.GetComponent<Image>().color; //Could glow
        if(thisButton.tag != "Minister")
        {
            if(thisButton.interactable || thisButton.GetComponent<Image>().color != Color.black) this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            else this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void AdquireColor()
    {
        /*matMinister = this.gameObject.GetComponent<MeshRenderer>().material;
        matHead = head.GetComponent<MeshRenderer>().material;*/
        gameObject.GetComponent<MeshRenderer>().material.color = thisButton.GetComponent<Image>().material.color;
    }

    public void Selected()
    {
        Debug.Log("Selected button " + thisButton.name);

        if (canBeInteracted) thisButton.onClick.Invoke();
    }
}
