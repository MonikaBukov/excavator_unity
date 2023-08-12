using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAnimationController : MonoBehaviour
{
    public Animator animator;
    public float leftSpeed;
    public float rightSpeed;
    public float transitionTime = 0.2f;

    void Update()
    {
        if (animator.GetBool("Moving"))
            {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float normalizedLeftSpeed = leftSpeed / 10.0f;
            float normalizedRightSpeed = rightSpeed / 10.0f;
            animator.SetFloat("LeftSpeed", normalizedLeftSpeed);
            animator.SetFloat("RightSpeed", normalizedRightSpeed);

            if (normalizedLeftSpeed != normalizedRightSpeed)
            {
                animator.CrossFade("LeftTrack", transitionTime);
                animator.CrossFade("RightTrack", transitionTime);
            }

            if (horizontal != 0.0f || vertical != 0.0f)
            {
                float speed = Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical));

                if (horizontal < 0.0f)
                {
                    leftSpeed = -speed;
                    rightSpeed = speed;
                }
                else if (horizontal > 0.0f)
                {
                    leftSpeed = speed;
                    rightSpeed = -speed;
                }
                else if (vertical > 0.0f)
                {
                    leftSpeed = speed;
                    rightSpeed = speed;
                }
                else
                {
                    leftSpeed = -speed;
                    rightSpeed = -speed;
                }

                animator.SetFloat("LeftSpeed", leftSpeed);
                animator.SetFloat("RightSpeed", rightSpeed);
            }
            else
            {
                animator.SetFloat("LeftSpeed", 0.0f);
                animator.SetFloat("RightSpeed", 0.0f);
            }
        }
    }
}
