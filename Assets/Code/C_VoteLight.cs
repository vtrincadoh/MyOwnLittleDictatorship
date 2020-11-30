using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class C_VoteLight : MonoBehaviour
{
    public Image VoteKind;
    private Color initialColor;
    private Light vote;
    

    // Start is called before the first frame update
    void Start()
    {
        vote = this.gameObject.GetComponent<Light>();
        initialColor = VoteKind.color;
        Reset();
    }

    private void Update()
    {
        if (VoteKind.color != Color.gray)
        {
            vote.range = 5;
            vote.color = VoteKind.color;
            vote.intensity = 1;
        }
        else Reset();
    }

    private void Reset()
    {
        vote.range = 0;
        vote.color = Color.gray;
        vote.intensity = 0;
    }
}
