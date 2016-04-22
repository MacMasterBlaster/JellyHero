using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

    public delegate void OnUpdateHealth(HealthController healthController);     //descibes funtion but does nothing
    public static event OnUpdateHealth onUpdateHealthEvent;

    public float maxHealth = 10;
    public float health;

    void Awake()
    {
        health = maxHealth;

        if (onUpdateHealthEvent != null)
        {
            onUpdateHealthEvent(this);
        }

    }

    public float HealthPct()
    {
        return health / maxHealth;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        OnTakeDamage(collision.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        OnTakeDamage(collider.gameObject);
    }

    void OnTakeDamage(GameObject go)
    {
        DamageContoller damageController = go.GetComponent<DamageContoller>();
        if (damageController != null)
        {
            health -= damageController.damage;
            if (health <= 0)
            {
                health = 0;
                gameObject.SetActive(false);
            }

            if (onUpdateHealthEvent != null)
            {
                onUpdateHealthEvent(this);
            }
        }
    }
}
