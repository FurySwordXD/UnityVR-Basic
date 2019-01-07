using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorButton : VRButton
{
    public List<Material> materials;
    private int index = 1;
    // Start is called before the first frame update
    void Start()
    {  
        foreach (Material mat in materials)
        {
            if (interactable.gameObject.GetComponent<Renderer>().material.name.Contains(mat.name))
            {
                index = materials.IndexOf(mat);
                break;
            }
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ButtonAction()
    {
        base.ButtonAction();
        if (index < materials.Count-1)
            index += 1;
        else
            index = 0;
        interactable.gameObject.GetComponent<Renderer>().material = materials[index];

    }
}
