using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCameras : MonoBehaviour
{
    public Camera FollowPlayerCamera;
    public Camera FollowDiggerCamera;
    public Camera StaticCamera;
    public Camera PiPCam;
    public Animator anim;
    public GameObject PlayerCharacter;
    public GameObject Digger;


    // Start is called before the first frame update
    void Start()
    {
        FollowPlayerCamera.enabled = true;
        StaticCamera.enabled = false;
        FollowDiggerCamera.enabled = false;
        PiPCam.enabled = false;
        PlayerCharacter.GetComponent<AudioListener>().enabled = true;
        Digger.GetComponent<AudioListener>().enabled = false;
        StaticCamera.GetComponent<AudioListener>().enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PiPCam.enabled = !PiPCam.enabled;
        }
        if (anim.GetBool("Moving"))
        {
            PlayerCharacter.GetComponent<AudioListener>().enabled = false;
            Digger.GetComponent<AudioListener>().enabled = true;
            FollowPlayerCamera.enabled = false;
            FollowDiggerCamera.enabled = true;
        }
        else if (!anim.GetBool("Moving") && !StaticCamera.enabled)
        {

            FollowPlayerCamera.enabled = true;
            FollowDiggerCamera.enabled = false;
            PlayerCharacter.GetComponent<AudioListener>().enabled = true;
            Digger.GetComponent<AudioListener>().enabled = false;
            StaticCamera.GetComponent<AudioListener>().enabled = false;

        }

        }

    }


  