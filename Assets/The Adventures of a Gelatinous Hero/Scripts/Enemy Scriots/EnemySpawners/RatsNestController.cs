using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class RatsNestController : MonoBehaviour {

    //public float spawnTriggerDistance = 3;
    public float spawnInterval = .5f;
    public float maxRatsSpawned = 5;
    public PlayerControllerComponentAnimation player;

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

    protected bool isPlayerPresent = false;

    private BoxCollider2D _bc;
    private CircleCollider2D _cc;

    void Awake()
    {
        _bc = gameObject.GetComponent<BoxCollider2D>();
        _cc = gameObject.GetComponent<CircleCollider2D>();
    }

    IEnumerator IsPlayerPresent()
    {
        if (isPlayerPresent)
        {
            Spawner.Spawn("DireRat");
        }
        yield return new WaitForSeconds(spawnInterval);
    }

    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.tag == "Player")
        {
            isPlayerPresent = true;
            Debug.Log("HERE");
        }
    }
}
