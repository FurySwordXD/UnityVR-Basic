using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRController : MonoBehaviour
{
    //Teleportation Variables
    public float speed = 100.0f;
    private Transform myCamera;
    private RaycastHit ray;
    private bool rayHit;
    private Vector3 targetPosition;
    private bool move = false;

    //Fade Variables
    Texture2D blk;
    public float fadeInRate = 5.0f;
    public float fadeOutRate = 5.0f;
    private float alpha;

    //Gaze Variables
    private bool gazeStatus;
    private float gazeTimer;
    private Image gazeImage;
    public float gazeDuration = 1.0f;
    public GameObject interactable;

    // Start is called before the first frame update
    void Start()
    {
        myCamera = this.GetComponentInChildren<Camera>().transform;

        gazeImage = this.GetComponentInChildren<Image>();
        blk = new Texture2D(1, 1);
        blk.SetPixel(0, 0, new Color(0, 0, 0, 1));
        blk.Apply();

        alpha = 1;
    }


    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blk);
    }

    // Update is called once per frame
    void Update()
    {
        TraceLocation();
        Gaze();
        HandleInput();

        if (move)
        {
            FadeOut();
            MoveToTarget();
        }
        else
        {
            FadeIn();
        }
    }

    void Gaze()
    {
        if (gazeStatus)
        {
            gazeTimer += Time.deltaTime;
            gazeImage.fillAmount = gazeTimer / gazeDuration;
        }
        if (gazeTimer >= gazeDuration)
        {
            interactable.GetComponent<Interactable>().Interact(this);
            GazeOff();  
        }
    }
    public void GazeOn(GameObject interactableObject)
    {
        gazeStatus = true;
        interactable = interactableObject;
    }
    public void GazeOff()
    {
        gazeStatus = false;
        gazeTimer = 0;
        gazeImage.fillAmount = 0;
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            SetTarget();
        }
    }

    void SetTarget()
    {
        if (rayHit)
        {
            targetPosition = ray.point + ray.normal * 2;
            move = true;
        }
    }

    void MoveToTarget()
    {
        /*float distance = Vector3.Distance(this.transform.position, targetPosition);

        if (distance > 0)
        {
            float step = speed * Time.deltaTime;
            if (alpha == 1)
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, step);
                
        }
        else
            move = false;*/

        if (alpha == 1)
        {
            this.transform.position = targetPosition;
            move = false;
        }
    }

    void TraceLocation()
    {

        if (Physics.Raycast(myCamera.position, myCamera.TransformDirection(Vector3.forward), out ray))
        {
            Debug.DrawRay(myCamera.position, myCamera.TransformDirection(Vector3.forward) * ray.distance, Color.green);
            rayHit = true;

            if (ray.transform.gameObject.GetComponent<Interactable>())
            {
                if (interactable != ray.transform.gameObject)
                    GazeOn(ray.transform.gameObject);
            }
            else
            {
                interactable = null;
                GazeOff();
            }     
        }
        else
        {
            Debug.DrawRay(myCamera.position, myCamera.TransformDirection(Vector3.forward) * 1000, Color.red);
            rayHit = false;
            GazeOff();
        }
    }

    void FadeIn()
    {
        if (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeInRate;
            if (alpha < 0) { alpha = 0f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alpha));
            blk.Apply();
        }
    }
    void FadeOut()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime * fadeOutRate;
            if (alpha > 1) { alpha = 1f; }
            blk.SetPixel(0, 0, new Color(0, 0, 0, alpha));
            blk.Apply();
        }
    }
}
