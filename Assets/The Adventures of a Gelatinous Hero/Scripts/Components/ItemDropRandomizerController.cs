using UnityEngine;
using System.Collections;

public class ItemDropRandomizerController : MonoBehaviour {

    [Range(0, 1)]
    public float dropChance = 0.1f;

    public string[] itemDrops;

    private HealthController healthController;

    void Awake ()
    {
        healthController = GetComponent<HealthController>();
    }
    void OnEnable()
    {
        healthController.onDeath += SpawnRandom;
    }

    void OnDisable()
    {
        healthController.onDeath -= SpawnRandom;
    }

    string ChooseRandomPrefab()
    {
        int i = Random.Range(0, itemDrops.Length);
        return itemDrops[i];
    }
    void SpawnRandom()
    {
        if (dropChance < 0.5f)
        {
            Spawner.Spawn(ChooseRandomPrefab());
        }
    }
}
