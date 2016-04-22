using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionManager : MonoBehaviour {
    public static ExplosionManager instance;

    public GameObject explosionPrefab;

    private List<GameObject> spawnedExplosions = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnEnable()
    {
        StartCoroutine("SpawnCoroutine");
    }

    IEnumerator SpawnCoroutine()
    {
        Spawn();
        yield return new WaitForEndOfFrame();
    }

    public static void SpawnExplosion()
    {
        instance.StartCoroutine("SpawnCoroutine");
    }

    void Spawn()
    {
        GameObject explosion = spawnedExplosions.Find(IsInactiveExplosion);

        if (explosion == null)
        {
            explosion = Object.Instantiate(explosionPrefab) as GameObject;
            spawnedExplosions.Add(explosion);
        }
        else
        {
            explosion.SetActive(true);
        }

        explosion.transform.position = transform.position;
    }

    bool IsInactiveExplosion(GameObject explosion)
    {
        return !explosion.activeSelf;
    }
}//EndOfScript
