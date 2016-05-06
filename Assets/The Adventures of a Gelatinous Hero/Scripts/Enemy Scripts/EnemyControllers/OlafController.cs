using UnityEngine;
using System.Collections;

public class OlafController : MonoBehaviour
{

    public float walkSpeed = 1;
    public float jumpSpeed = 3;
    public float attackInterval = .3f;
    public float walkTime = 5;
    public float jumpTime = 1;
    public float waitTime = 2;
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
        if (healthController.health <= 10)
        {
            animator.SetTrigger("Swipe");
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
