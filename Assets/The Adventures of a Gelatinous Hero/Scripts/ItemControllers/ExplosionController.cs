using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]

public class ExplosionController : MonoBehaviour {

    public float startSize = 1;
    public float endSize = 5;
    public float explosionLength = 1;

    public CircleCollider2D cc
    {
        get
        {
            if (_cc == null)
            {
                _cc = gameObject.GetComponent<CircleCollider2D>();
            }
            return _cc;
        }
    }

    private CircleCollider2D _cc;

    void OnEnable()
    {
        StartCoroutine("ExplosionCoroutine");
    }

    IEnumerator ExplosionCoroutine()
    {
        float t = 0;
        while (t <= explosionLength)
        {
            t += Time.deltaTime;
            float fraction = t / explosionLength;
            cc.radius = Mathf.Lerp(startSize, endSize, fraction);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
