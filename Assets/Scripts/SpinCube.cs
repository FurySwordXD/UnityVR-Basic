using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCube : Interactable
{
    public float speed = 90.0f;
    public GameObject uiPrefab;
    private GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    public void FlipSpin()
    {
        speed = -speed;
    }

    public override void Interact(VRController player)
    {
        base.Interact(player);
        if (ui == null)
        { 
            ui = Instantiate(uiPrefab, transform.position, Quaternion.LookRotation(transform.position - player.transform.position, Vector3.up)) as GameObject;
            foreach (var button in ui.GetComponentsInChildren<VRButton>())
            {
                button.interactable = transform.gameObject;
            }
        }
    }
}
