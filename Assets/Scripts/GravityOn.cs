using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOn : MonoBehaviour
{
    private Rigidbody thisRigid;
    // Start is called before the first frame update
    void Start()
    {
        thisRigid = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("g"))
        {
            thisRigid.useGravity= true;
        }
        
    }
}
