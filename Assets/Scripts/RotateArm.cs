using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateArm : MonoBehaviour
{

    // Define the rotation speed and the angle increment for the rotation
    public float rotationSpeed = 10f;
    private int minAngle = 330;
    private int maxAngle = 30;
    public GameObject topPart;
    public Animator diggerAnim;
    public AudioSource rotationMovement;
    private bool isRotating = false;

    void Update()
    {
        float rotationY = topPart.transform.localEulerAngles.y;
        if ((rotationY >= minAngle || rotationY <= maxAngle || rotationY == 0))
        {
            if (diggerAnim.GetBool("Moving"))
                {
                if (Input.GetKey(KeyCode.Alpha3))
                {
                    if ((rotationY >= minAngle + 1 || rotationY <= maxAngle) || rotationY == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Alpha3))
                        {
                            isRotating = true;
                            rotationMovement.Play();
                        }
                        

                        topPart.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        isRotating = false;
                        rotationMovement.Stop();
                    }

                }
                else if (Input.GetKey(KeyCode.Alpha4))
                {
                    if ((rotationY <= maxAngle - 1 || rotationY >= minAngle) || rotationY == 0)
                    {
                        if (Input.GetKeyDown(KeyCode.Alpha4))
                        {
                            isRotating = true;
                            rotationMovement.Play();
                        }
                       

                        topPart.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
                    }
                    else
                    {
                        isRotating = false;
                        rotationMovement.Stop();
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Alpha4))
                {
                    isRotating = false;
                    rotationMovement.Stop();
                }
                else if (Input.GetKeyUp(KeyCode.Alpha3))
                {
                    isRotating = false;
                    rotationMovement.Stop();
                }
            }
        }
    }
}
