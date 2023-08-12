using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMachine : MonoBehaviour
{
    public GameObject player;
    public Animator diggerAnim;
    private Animator playerAnim;
    public Transform targetObject;
    public AudioSource diggerNoise;

    void Start()
    {
        playerAnim = player.GetComponent<Animator>();
        diggerNoise.Stop();

    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision!");

        AnimatorStateInfo pstate = playerAnim.GetCurrentAnimatorStateInfo(0);
        int armLayerIndex = playerAnim.GetLayerIndex("PickingUp");
        AnimatorStateInfo pstateInfo = playerAnim.GetCurrentAnimatorStateInfo(armLayerIndex);

        AnimatorStateInfo state = diggerAnim.GetCurrentAnimatorStateInfo(0);
        int doorLayerIndex = diggerAnim.GetLayerIndex("Base Layer");
        AnimatorStateInfo stateInfo = diggerAnim.GetCurrentAnimatorStateInfo(doorLayerIndex);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (stateInfo.IsName("DoorOpening"))
            {
                if (pstateInfo.IsName("PickingUpKey"))
                {
                    diggerAnim.SetBool("Open", false);
                    diggerAnim.SetBool("Close", true);
                    diggerAnim.SetBool("Moving", true);
                    player.SetActive(false);
                    diggerNoise.Play();
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (diggerAnim.GetBool("Moving"))
            {
                diggerAnim.SetBool("Moving", false);
                diggerAnim.SetBool("Close", false);
                diggerAnim.SetBool("Open", true);
                Debug.Log(diggerAnim.GetBool("Open"));
                Debug.Log(diggerAnim.GetBool("Close"));
                diggerNoise.Stop();
                player.transform.position = targetObject.position;
                player.SetActive(true);

            }

        }
    }
}
