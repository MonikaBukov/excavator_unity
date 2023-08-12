using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCamera : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;
    public bool retroOrtho =false;
    public Camera thisCamera;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        transform.position = desiredPosition;
        transform.LookAt(target.transform.position);

        if(retroOrtho)
        {
            thisCamera.orthographic = true;
        }
        else
        {
            thisCamera.orthographic = false;
        }

    }
}
