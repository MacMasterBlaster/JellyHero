using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemDropPrefabController : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float frameInterval = .2f;
    private Sprite[] currentSprites;
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

    void Awake()
    {
        while (enabled)
        {
            StartCoroutine("Animate");
        }
    }

    IEnumerator Animate()
    {
        for (int i = 0; i <= animationSprites.Length; i++)
        {
            spriteRenderer.sprite = currentSprites[i];
        }
        yield return new WaitForSeconds(frameInterval);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Debug.Log("You Got Me");
        }
    }
}
