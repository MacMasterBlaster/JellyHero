using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour
{
    //public GameObject explosionPrefab;

    //bomb specific settings:
    public float timeDelay = 3;
    public Color flickerColor01 = new Color(255, 255, 255, 255);
    protected Color flickerColor02 = new Color(255, 255, 255, 255);

    public SpriteRenderer sr
    {
        get
        {
            if (_sr == null)
            {
                _sr = GetComponent<SpriteRenderer>();
            }
            return _sr;
        }
    }

    private SpriteRenderer _sr;
    //private GameObject explosion;

    void OnEnable()
    {
        //explosion = Object.Instantiate(explosionPrefab) as GameObject;
        StartCoroutine("FlickerThenExplode");
    }

    IEnumerator FlickerThenExplode()
    {
        int numFlickers = 10;
        for (int i = 0; i < numFlickers; i ++)
        {
            sr.color = (i % 2 == 0) ? flickerColor01 : flickerColor02;
            yield return new WaitForSeconds(timeDelay / (float)numFlickers);
        }

        //explosion.transform.position = transform.position;
        //explosion.SetActive(true);
        ExplosionManager.SpawnExplosion();
        gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
