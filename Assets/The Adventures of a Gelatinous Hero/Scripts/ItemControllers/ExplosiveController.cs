using UnityEngine;
using System.Collections;

public class ExplosiveController : MonoBehaviour
{
    //bomb specific settings:
    public float timeDelay = 0.5f;
    public Color flickerColor = new Color(255, 255, 255, 255);
    public string craterPrefabName;
    public bool isTriggered = false;

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

    private Color baseColor;
    //private HealthController healthController;
    private SpriteRenderer _sr;

    void OnEnable()
    {
        baseColor = sr.color;
        if (!isTriggered)
        {
            StartCoroutine("FlickerThenExplode");
        }
        //else
        //{
        //    healthController = GetComponent<HealthController>();
        //}
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

        if (craterPrefabName != null)
        {
            GameObject crater = Spawner.Spawn(craterPrefabName);
            crater.transform.position = transform.position;
        }
        yield return new WaitForEndOfFrame();
    }

    void OnDeath()
    {
        if (isTriggered)
        {
            StartCoroutine("FlickerThenExplode");
        }
    }

}
