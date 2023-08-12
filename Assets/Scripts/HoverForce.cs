using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverForce : MonoBehaviour
{
    public float hoverEnergy = 20.0f;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody holder = other.GetComponent<Rigidbody>();
        holder.AddForce(Vector3.up * hoverEnergy, ForceMode.Acceleration);
        Vector3 turn = new Vector3(0.1f, 0.1f, 0.1f);
        holder.AddRelativeTorque(turn);
    }
}
