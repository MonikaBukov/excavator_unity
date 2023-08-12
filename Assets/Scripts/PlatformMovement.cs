using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject startPos;
    public GameObject endPos;

    public float speed = 3f;
    private bool to = true;
    private float elapsedTime = 0;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        player.transform.parent = null;
    }

    private void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float step = speed * Time.deltaTime;

        if (elapsedTime > 2f)
        {
            if (to == true)
            {

                if (transform.position == endPos.transform.position)
                {
                    to = false;
                    elapsedTime = 0;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, endPos.transform.position, step);
                }
            }
            if (to == false)
            {

                if (transform.position == startPos.transform.position)
                {
                    to = true;
                    elapsedTime = 0;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPos.transform.position, step);
                }
            }

        }
    }
}
