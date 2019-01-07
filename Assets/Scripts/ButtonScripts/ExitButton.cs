using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : VRButton
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
        Destroy(transform.root.gameObject);
    }
}
