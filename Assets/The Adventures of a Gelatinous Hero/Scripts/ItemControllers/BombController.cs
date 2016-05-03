using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour
{
    //bomb specific settings:
    public float timeDelay = 0.5f;
    public Color flickerColor = new Color(255, 255, 255, 255);
    protected Color baseColor;

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

    void OnEnable()
    {
        baseColor = sr.color;
        StartCoroutine("FlickerThenExplode");
    }

    IEnumerator FlickerThenExplode()
    {
        int numFlickers = 10;
        for (int i = 0; i < numFlickers; i ++)
        {   //alternates color
            sr.color = (i % 2 == 0) ? flickerColor : baseColor;
            yield return new WaitForSeconds(timeDelay / (float)numFlickers);
        }
        GameObject explosion = Spawner.Spawn("Explosion");
        explosion.transform.position = transform.position;
        gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
