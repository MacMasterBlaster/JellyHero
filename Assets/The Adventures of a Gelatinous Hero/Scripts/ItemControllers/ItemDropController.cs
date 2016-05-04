﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemDropController : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float frameInterval = .2f;
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }

    void OnEnable()
    {
        StartCoroutine("Animate");
    }

    IEnumerator Animate()
    {
        while (enabled)
        {
            for (int i = 0; i < animationSprites.Length; i++)
            {
                spriteRenderer.sprite = animationSprites[i];
                yield return new WaitForSeconds(frameInterval);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Debug.Log("You Got Me");
        }
    }
}