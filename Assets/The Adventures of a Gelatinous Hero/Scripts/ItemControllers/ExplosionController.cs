using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]

public class ExplosionController : MonoBehaviour {

    public float startSize = .5f;
    public float endSize = 1.5f;
    public float explosionLength = .3f;

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
        cc.radius = endSize;
        gameObject.SetActive(false);
    }
}
