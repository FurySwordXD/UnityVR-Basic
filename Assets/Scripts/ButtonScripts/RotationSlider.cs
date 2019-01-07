using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationSlider : VRButton
{
    public float fillTime = 2.0f;
    public Slider mySlider;

    private float timer;
    private bool gazeStatus;
    private bool increase = true;

    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        interactable.transform.eulerAngles = mySlider.value * new Vector3(0.0f, 360.0f, 0.0f);

        if (gazeStatus)
        {
            if (increase)
            {
                if (timer < fillTime)
                {
                    timer += Time.deltaTime;
                }
                else
                    increase = false;
            }

            else
            {
                if (timer > 0)
                    timer -= Time.deltaTime;
                else
                    increase = true;
            }

            mySlider.value = timer / fillTime;
        }
    }

    public virtual void PointerEnter()
    {
        gazeStatus = true;
    }

    public virtual void PointerExit()
    {
        gazeStatus = false;

    }

    /*public IEnumerator FillBar()
    {
        while (timer < fillTime)
        {
            timer += Time.deltaTime;
            mySlider.value = timer / fillTime;
            yield return null;
        }
    }

    public IEnumerator EmptyBar()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            mySlider.value = timer / fillTime;
            yield return null;
        }
    }*/
}
