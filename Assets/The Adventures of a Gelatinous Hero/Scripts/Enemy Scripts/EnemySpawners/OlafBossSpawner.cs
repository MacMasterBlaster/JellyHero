using UnityEngine;
using System.Collections;

public class OlafBossSpawner : MonoBehaviour
{
    public CircleCollider2D cc
    {
        get
        {
            return _cc;
        }
    }

    private CircleCollider2D _cc;

    void Awake()
    {
        _cc = gameObject.GetComponent<CircleCollider2D>();
    }

    IEnumerator SpawnCoroutine()
    {
        GameObject boss = Spawner.Spawn("Olaf");
        boss.transform.position = gameObject.transform.position;
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("StartingBossFight!");
            StartCoroutine("SpawnCoroutine");
        }
    }
}
