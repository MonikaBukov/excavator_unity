using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateDust : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    public int maxParticles = 5;

    private List<GameObject> particleEffectPool;
    public ParticleSystem stones;
    public Collider terrainCollider;


    private void Start()
    {
        var stone_emission = stones.emission;
        stone_emission.enabled = false;
        particleEffectPool = new List<GameObject>();
        for (int i = 0; i < maxParticles; i++)
        {
            GameObject particleEffectObject = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            particleEffectObject.SetActive(false);
            particleEffectPool.Add(particleEffectObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var stone_emission = stones.emission;
        if (other == terrainCollider)
        {
            stone_emission.enabled = true;
        }

        //get a particle effect from the pool
        GameObject particleEffectObject = GetAvailableParticleEffect();
        if (particleEffectObject == null)
        {
            return;
        }

        particleEffectObject.transform.position = transform.position;

        ParticleSystem particleSystemInstance = particleEffectObject.GetComponent<ParticleSystem>();
        particleSystemInstance.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        var stone_emission = stones.emission;
        stone_emission.enabled = false;
        // stop all particle systems in the pool
        foreach (GameObject particleEffectObject in particleEffectPool)
        {
            ParticleSystem particleSystemInstance = particleEffectObject.GetComponent<ParticleSystem>();
            if (particleSystemInstance.isPlaying)
            {
                particleSystemInstance.Stop();
                StartCoroutine(DeactivateParticleEffect(particleEffectObject));
            }
        }
    }

    private GameObject GetAvailableParticleEffect()
    {
  
        foreach (GameObject particleEffectObject in particleEffectPool)
        {
            if (!particleEffectObject.activeSelf)
            {
                particleEffectObject.SetActive(true);
                return particleEffectObject;
            }
        }
        return null;
    }

    private IEnumerator DeactivateParticleEffect(GameObject particleEffectObject)
    {
        // if it finished it will stop
        yield return new WaitForSeconds(particleEffectObject.GetComponent<ParticleSystem>().main.duration);
        particleEffectObject.SetActive(false);
    }
}





