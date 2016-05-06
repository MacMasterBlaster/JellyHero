using UnityEngine;
using System.Collections;

public class GasPipeSputterController : MonoBehaviour {

    [Range(0, 1)] public float sputterChance = 0.1f;
    public float maxTimeActive = 5;
    public float minTimeActive = 1;
    public float timeInactive = 3;

    private float timeActive;

    private BoxCollider2D bc;
    private ParticleSystem gas;
    void Awake()
    {
        gas = GetComponent<ParticleSystem>();
        bc = GetComponent<BoxCollider2D>();
        timeActive = Random.Range(minTimeActive, maxTimeActive);
        StartCoroutine("Sputter");
    }

    IEnumerator Sputter()
    {
        while (enabled)
        {
            if (Random.value > sputterChance)
            {
                gas.enableEmission = true;
                bc.enabled = true;
                yield return new WaitForSeconds(timeActive);
            }
            else
            {
                gas.enableEmission = false;
                bc.enabled = false;
                yield return new WaitForSeconds(timeInactive);
            }
        }
    }
}
