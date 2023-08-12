using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggerController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;
    public float distanceToGround = 0.0f;
    public Animator anim;
    public AudioSource trackSource;
    public AudioSource reverseSource;
    private bool isTrackPlaying = false;
    private bool isReversePlaying = false;
    public ParticleSystem dust;
    public ParticleSystem smoke;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        distanceToGround =1.6f;
        

    }
    
    void FixedUpdate()
    {
        if (anim.GetBool("Moving"))
        {
 
            var main = dust.main;
            var emission = dust.emission;
            var emission_smoke = smoke.emission;

            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * turnSpeed;

            if (translation != 0.0f || rotation != 0.0f)
            {
                if (emission.rateOverTimeMultiplier < 200)
                {
                    dust.gameObject.SetActive(true);
                    main.startSizeMultiplier += Time.deltaTime * 1.0f;
                    emission.rateOverTimeMultiplier += Time.deltaTime * 10.0f;
                }
                if (!isTrackPlaying)
                {
                    smoke.gameObject.SetActive(true);
                    emission_smoke.enabled = true;
                    dust.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                    trackSource.Play();
                    isTrackPlaying = true;
                }

                if (translation < 0.0f && !isReversePlaying)
                {
                    dust.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    reverseSource.Play();
                    isReversePlaying = true;
                    smoke.gameObject.SetActive(true);
                    emission_smoke.enabled = true;

                }

            }
            else
            {

                main.startSizeMultiplier -= Time.deltaTime * 1.0f;
                emission.rateOverTimeMultiplier -= Time.deltaTime * 20.0f;
                if (isTrackPlaying)
                {
                    trackSource.Stop();
                    isTrackPlaying = false;
                    
                    emission_smoke.enabled = false;
                }
                if (isReversePlaying)
                {
                    reverseSource.Stop();
                    isReversePlaying = false;
                }
            }

            rb.MovePosition(transform.position + transform.forward * translation * Time.fixedDeltaTime);
            rb.MoveRotation(transform.rotation * Quaternion.Euler(0, rotation * Time.fixedDeltaTime, 0));

            RaycastHit hit;
            Vector3 raycastOrigin = transform.position + Vector3.down * (distanceToGround + 0.1f);
            Debug.DrawRay(raycastOrigin, -Vector3.up * (distanceToGround + 0.1f), Color.green, 1.0f);
            GameObject groundObject = GameObject.Find("Ground");
            if (groundObject != null)
            {
                Transform groundTransform = groundObject.transform;
                if (Physics.Raycast(raycastOrigin, -groundTransform.up, out hit, distanceToGround + 0.1f, LayerMask.GetMask("Ground")))
                {
                    float distance = hit.distance - distanceToGround;
                    transform.position = hit.point + Vector3.up * distanceToGround;
                }
                else
                {
                    transform.position = transform.position;
                }

            }
        }

    }
}
