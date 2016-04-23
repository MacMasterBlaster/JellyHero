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

    public static GameObject SpawnExplosion()
    {
        return instance.Spawn();
    }

    public GameObject Spawn()
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
        return explosion;
    }

    bool IsInactiveExplosion(GameObject explosion)
    {
        return !explosion.activeSelf;
    }
}//EndOfScript
