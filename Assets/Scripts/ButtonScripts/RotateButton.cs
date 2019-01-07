using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : VRButton
{

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
        interactable.GetComponent<SpinCube>().FlipSpin();
    }
}
