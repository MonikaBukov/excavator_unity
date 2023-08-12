using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.TimeZoneInfo;


public class CameraTrigger : MonoBehaviour
{
    public Camera triggeredCam;
    public Camera liveCam;
    public GameObject keys;
    public float transitionDuration = 2f;
    private float transitionTimer = 0f;
    public Collider PlayerCollider;
    private void Awake()
    {
      //  liveCam = Camera.allCameras[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other ==  PlayerCollider && keys.activeSelf)
        {
            triggeredCam.enabled = true;
            liveCam.enabled = false;
          //  liveCam = Camera.allCameras[0];
            triggeredCam.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            return;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == PlayerCollider)
        {
            liveCam.enabled = true;
            triggeredCam.enabled = false;

           // liveCam = Camera.allCameras[0];
            triggeredCam.GetComponent<AudioListener>().enabled = false;
           
        }
        else
        {
            return;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (!keys.activeSelf)
        {
            triggeredCam.enabled = false;
            triggeredCam.GetComponent<AudioListener>().enabled = false;
            liveCam.enabled = true;

            // Gradually decrease the field of view of the triggered camera and increase the field of view of the live camera
            transitionTimer += Time.deltaTime;
            float t = Mathf.Clamp01(transitionTimer / transitionDuration);
            triggeredCam.fieldOfView = Mathf.Lerp(60f, 20f, t);
            liveCam.fieldOfView = Mathf.Lerp(20f, 60f, t);

            // Deactivate the trigger after the transition is complete
            if (t >= 1f)
            {
                triggeredCam.enabled = false;
                triggeredCam.GetComponent<AudioListener>().enabled = false;
                liveCam.enabled = true;
                gameObject.SetActive(false);
                transitionTimer = 0f;
            }
        }
        else
        {
            return;
        }
    }

}
