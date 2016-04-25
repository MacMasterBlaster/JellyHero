using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombManager : MonoBehaviour {
    public static BombManager instance;

    public GameObject bombPrefab;
    public int maxBombs = 5;
    private int currentNumBombs;
    private List<GameObject> spawnedBombs = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public static GameObject SpawnBomb()
    {
        return instance.Spawn();
    }

    GameObject Spawn()
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
        return bomb;
    }

    bool IsInactiveBomb(GameObject bomb)
    {
        return !bomb.activeSelf;
    }
}
