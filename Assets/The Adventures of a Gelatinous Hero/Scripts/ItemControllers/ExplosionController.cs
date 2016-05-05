﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]

public class ExplosionController : MonoBehaviour {

    public float colliderLifeTime = 1;
    public float colliderSize = 1.5f;
    public float explosionLifeTime = 1.5f;

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
        cc.radius = colliderSize;
        yield return new WaitForSeconds(colliderLifeTime);
        cc.enabled = false;
        yield return new WaitForSeconds(explosionLifeTime - colliderLifeTime);
        gameObject.SetActive(false);
    }
}
