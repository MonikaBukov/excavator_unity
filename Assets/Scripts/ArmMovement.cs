using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class ArmMovement : MonoBehaviour
{
    public Animator animator;
    private bool isSpinning = false;
   
    private float spinSpeed = 0.0f;
    public AudioSource startSpin;
    public AudioSource spinLoop;
    public AudioSource stopSpin;
    public AudioSource startArm;
    public AudioSource endArm;
    public MeshCollider spinningWheelTrigger;
  

    void Start()
    {
        animator = GetComponent<Animator>();
        isSpinning = false;
        spinningWheelTrigger.enabled = false;

    }
    void StopAudioClip()
    {
        startArm.Stop();
    }
    void Update()
    {

        if (Input.GetKeyUp("1"))
        {
            if (!isSpinning)
            {
                if (animator.GetBool("Moving"))
                {
                    startSpin.Play();
                    spinLoop.Play();
                    isSpinning = true;
                    spinningWheelTrigger.enabled = true;
                }
            }
        }
        else if (Input.GetKeyUp("2"))
        {
            if (isSpinning)
            {
                if (animator.GetBool("Moving"))
                {
                    startSpin.Stop();
                    spinLoop.Stop();
                    stopSpin.Play();
                    isSpinning = false;
                    spinningWheelTrigger.enabled = false;
                }
            }
        }
        if (isSpinning)
        {
            if (spinSpeed < 1.0f)
            {
                spinSpeed += Time.deltaTime;
                animator.SetFloat("SpinSpeed", spinSpeed);
            }
        }
        else if (!isSpinning)
        {
            if (spinSpeed >= 0)
            {
                spinSpeed -= Time.deltaTime;
                animator.SetFloat("SpinSpeed", spinSpeed);
            }
        }

        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        //Animator animator = GetComponent<Animator>();
        int armLayerIndex = animator.GetLayerIndex("Arm");
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(armLayerIndex);

        if (stateInfo.IsName("ArmMiddle"))
        {
            animator.SetBool("LetDown", false);
            animator.SetBool("Release", false);
            animator.SetBool("LiftUp", false);
            animator.SetBool("LiftBack", false);

            if (Input.GetKeyDown("5"))
            {
                animator.SetBool("LiftUp", true);
                startArm.Play();
                Invoke("StopAudioClip", 0.7f);

            }
            if (Input.GetKeyDown("6"))
            {
                animator.SetBool("LetDown", true);
                startArm.Play();
                Invoke("StopAudioClip", 0.7f);
            }
        }
        else if (stateInfo.IsName("LiftArmUp"))
        {
            if (Input.GetKeyDown("6"))
            {
                
                animator.SetBool("Release", true);
                startArm.Play();
                Invoke("StopAudioClip", 0.7f);
            }
        }
        else if (stateInfo.IsName("LetArmDown"))
        {
            if (Input.GetKeyDown("5"))
            {
                animator.SetBool("LiftBack", true);
                startArm.Play();
                Invoke("StopAudioClip", 0.7f);

            }
        }
        
    }
}
