using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CircleCollider2D))]
public class RatsNestController : MonoBehaviour {

    public float spawnInterval = 1;
    public float spawnSpacing = 2f;

    public BoxCollider2D bc
    {
        get
        {
            return _bc;
        }
    }
    public CircleCollider2D cc
    {
        get
        {
            return _cc;
        }
    }

    private BoxCollider2D _bc;
    private CircleCollider2D _cc;
    private int currentRatsSpawned = 0;


    void Awake()
    {
        _cc = gameObject.GetComponent<CircleCollider2D>();
    }
    
    IEnumerator SpawnCoroutine()
    {
        while (enabled)
        {
            GameObject rat = Spawner.Spawn("DireRat");
            rat.transform.position = gameObject.transform.position + (Vector3)Random.insideUnitCircle * spawnSpacing;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Starting");
            StartCoroutine("SpawnCoroutine");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Stopping");
            StopCoroutine("SpawnCoroutine");
        }

    }
}
