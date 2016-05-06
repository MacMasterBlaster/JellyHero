using UnityEngine;
using System.Collections;
using Paraphernalia.Extensions;

public class HealingPuddleController : MonoBehaviour {

    public float maxHeal = 5;
    public float healthPerSecond = 1;
    public bool affectAncestor = true;
    private float remainingHeal;
    private float scaler;
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer sr
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

    public void CheckRemainingHealth()
    {
        if (remainingHeal <= 0)
        {
            gameObject.SetActive(false);
        }
    }

        void OnTriggerStay2D(Collider2D collider)
    {
        HealthController h = collider.gameObject.GetComponent<HealthController>();
        if (affectAncestor && h == null) h = collider.gameObject.GetAncestorComponent<HealthController>();
        if (h != null) h.Heal(healthPerSecond * Time.deltaTime, false);
        scaler = remainingHeal / maxHeal;
        remainingHeal = maxHeal - (healthPerSecond * Time.deltaTime);
        gameObject.transform.localScale *= scaler;
        //CheckRemainingHealth();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        HealthController h = collision.gameObject.GetComponent<HealthController>();
        if (h == null) h = collision.gameObject.GetAncestorComponent<HealthController>();
        if (h != null) h.Heal(healthPerSecond * Time.deltaTime, false);
        scaler = remainingHeal / maxHeal;
        remainingHeal = maxHeal - (healthPerSecond * Time.deltaTime);
        gameObject.transform.localScale *= scaler;
        //CheckRemainingHealth();
    }
}
