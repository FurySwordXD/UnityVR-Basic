using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleButton : VRButton
{
    private bool scaleUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ButtonAction()
    {
        base.ButtonAction();
        if (scaleUp)
            interactable.transform.localScale += new Vector3(.4f, .4f, .4f);
        else
            interactable.transform.localScale -= new Vector3(.4f, .4f, .4f);
    }   
}
