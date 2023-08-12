using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{
    public int dyingState;
    public int deadBool;
    public int walkState;
    public int shoutState;
    public int speedFloat;
    public int sneakingBool;
    public int shoutingBool;
    public int backwardsBool;
    public int sideSpeedFloat;


    private void Awake()
    {
        dyingState = Animator.StringToHash("BaseLayer.Dying");
        deadBool = Animator.StringToHash("Dead");
        walkState = Animator.StringToHash("Walk");
        shoutState = Animator.StringToHash("Shouting.Sout");
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        shoutingBool = Animator.StringToHash("Shouting");
        backwardsBool = Animator.StringToHash("Backwards");
        sideSpeedFloat = Animator.StringToHash("SideSpeed");
    }

}
