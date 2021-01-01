using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_3DRelatedScrollBar : MonoBehaviour
{
    public Slider thisBar,referenceBar;

    private void Start()
    {
        thisBar = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        thisBar.value = referenceBar.value;
    }
}
