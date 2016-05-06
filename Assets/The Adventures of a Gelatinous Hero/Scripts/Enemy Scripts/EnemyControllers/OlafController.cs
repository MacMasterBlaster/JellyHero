using UnityEngine;
using System.Collections;

public class OlafController : MonoBehaviour
{

    public float walkSpeed = 1;
    public float jumpSpeed = 10;
    public float attackInterval = 5;
    public float walkTime = 5;
    public float jumpTime = 5;
    public float waitTime = 2;
    public float agroHealth = 5;
    private Rigidbody2D _body;
    private Animator animator;
    private HealthController healthController;

    public Rigidbody2D body
    {
        get
        {
            return _body;
        }
    }

    void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        healthController = gameObject.GetComponent<HealthController>();

        StartCoroutine("Pattern");
    }

    IEnumerator Pattern()
    {
        body.velocity = Vector2.zero;
        yield return new WaitForSeconds(waitTime);
        body.velocity = Vector2.down * walkSpeed;
        yield return new WaitForSeconds(walkTime);
        body.velocity = Vector2.zero;
        if (healthController.health <= agroHealth)
        {
            animator.SetTrigger("Swing");
        }
        else
        {
            animator.SetTrigger("Thrust");
        }
    }

    public void Jump ()
    {
        body.velocity = Vector2.up * jumpSpeed;
    }
}
