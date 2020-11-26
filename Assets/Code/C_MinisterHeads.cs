using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MinisterHeads : MonoBehaviour
{
    public GameObject head;
    private Material matHead,matMinister;

    private void Start()
    {
        matMinister = this.gameObject.GetComponent<MeshRenderer>().material;
        matHead = head.GetComponent<MeshRenderer>().material;
    }

    public void Update()
    {
        matHead.color = matMinister.color;
    }
}
