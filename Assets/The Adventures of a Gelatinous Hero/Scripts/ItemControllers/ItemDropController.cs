using UnityEngine;
using System.Collections;
using Paraphernalia.Components;
using Paraphernalia.Utils;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class ItemDropController : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float frameInterval = .2f;
    public string itemName;
    public string itemPickUpSoundName;
    public bool randomize = false;
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
            int offset = Random.Range(0, animationSprites.Length - 1);
            if (!randomize) offset = 0;
            for (int i = 0; i < animationSprites.Length; i++)
            {
                spriteRenderer.sprite = animationSprites[(i + offset) % animationSprites.Length];
                yield return new WaitForSeconds(frameInterval);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.PlayEffect(itemPickUpSoundName);
            gameObject.SetActive(false);
            InventoryManager.AddToCount(itemName, 1);
        }
        else if (collision.gameObject.tag == "Water")
        {
            gameObject.SetActive(false);
        }
    }
}
