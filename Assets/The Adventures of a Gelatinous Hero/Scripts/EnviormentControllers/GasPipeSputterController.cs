using UnityEngine;
using System.Collections;
using Paraphernalia.Extensions;

public class GasPipeSputterController : MonoBehaviour {

    //[Range(0, 1)] public float sputterChance = 0.1f;
    //public float timeActive = 5;
    //public float timeInactive = 3;
    public float maxTimeInactive = 2; 
    private AudioSource audioSource;
    public AudioClip pipeWarning;
    public AudioClip pipeActive;

    private BoxCollider2D bc;
    private ParticleSystem gas;
    void Awake()
    {
        audioSource = gameObject.GetOrAddComponent<AudioSource>();
        gas = GetComponent<ParticleSystem>();
        bc = GetComponent<BoxCollider2D>();
        StartCoroutine("Sputter");
    }

    IEnumerator Sputter()
    {
        while (enabled)
        {
            float timeInactive = Random.Range(0.5f, maxTimeInactive);
            audioSource.clip = pipeWarning;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
            audioSource.clip = pipeActive;
            audioSource.Play();
            gas.Play();
            bc.enabled = true;
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
            gas.Stop();
            yield return new WaitForSeconds(timeInactive);
        }   
    }
}
