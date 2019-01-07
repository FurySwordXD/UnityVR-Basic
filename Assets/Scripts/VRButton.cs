using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : Interactable
{
    public GameObject interactable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact(VRController player)
    {
        base.Interact(player);
        ButtonAction();
    }

    public virtual void ButtonAction()
    {

    }
}
