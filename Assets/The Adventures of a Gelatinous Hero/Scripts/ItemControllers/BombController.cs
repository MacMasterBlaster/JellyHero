using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour
{
    //explosion specific setting:
    /*
    public float startSize = 1;
    public float endSize = 5;
    public float explosionLength = 1;
    */

    //the above settings are applied to this prefab.
    public GameObject explosionPrefab;

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
    private GameObject explosion;

    void OnEnable()
    {
        explosion = Object.Instantiate(explosionPrefab) as GameObject;
        explosion.SetActive(false);
        //StartCoroutine("FlickerThenExplode");
    }

    public void ActivateBomb()
    {
        gameObject.SetActive(true);
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

        explosion.transform.position = transform.position;
        explosion.SetActive(true);
        gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
