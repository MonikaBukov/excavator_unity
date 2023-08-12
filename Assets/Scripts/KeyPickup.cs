using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class KeyPickup: MonoBehaviour
{
    public bool isPickedUp = false;
    public Animator playerAnim;
    public Animator diggerAnim;


    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision!");

        AnimatorStateInfo state = playerAnim.GetCurrentAnimatorStateInfo(0);
        int armLayerIndex = playerAnim.GetLayerIndex("PickingUp");
        AnimatorStateInfo stateInfo = playerAnim.GetCurrentAnimatorStateInfo(armLayerIndex);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (stateInfo.IsName("PickingUpKey"))
            {
                Debug.Log("Picked up key!");

                isPickedUp = true;
                diggerAnim.SetBool("Open", true);
                gameObject.SetActive(false);
                
            }
        }
    }

}
