using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombManager : MonoBehaviour {
    public static BombManager instance;

    public GameObject bombPrefab;

    private List<GameObject> spawnedBombs = new List<GameObject>();

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

    public static void SpawnBomb()
    {
        instance.StartCoroutine("SpawnCoroutine");
    }

    void Spawn()
    {
        GameObject bomb = spawnedBombs.Find(IsInactiveBomb);

        if (bomb == null)
        {
            bomb = Object.Instantiate(bombPrefab) as GameObject;
            spawnedBombs.Add(bomb);
        }
        else
        {
            bomb.SetActive(true);
        }
    }

    bool IsInactiveBomb(GameObject bomb)
    {
        return !bomb.activeSelf;
    }
}//EndOfScript
