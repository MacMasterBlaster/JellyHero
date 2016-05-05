using UnityEngine;
using System.Collections;

public class OlafController : MonoBehaviour
{

    public float walkSpeed = 1;
    public float jumpSpeed = 3;
    public float attackInterval = .3f;
    public float walkTime = 5;
    public float jumpTime = 1;
    private Rigidbody2D _body;
    private Animator animator;

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
        //StartCoroutine("Walk");
        Charge();
    }

    void Charge()
    {
        StartCoroutine("Walk");
        ThrustAttack();
        StartCoroutine("Walk");
    }

    void ThrustAttack()
    {
        StartCoroutine("Thrust");
    }

    IEnumerator Thrust()
    {
        animator.SetTrigger("Thrust");
        StopCoroutine("Walk");
        //body.velocity = Vector2.zero;
        yield return new WaitForSeconds(attackInterval);
    }

    IEnumerator Walk()
    {
        body.velocity = Vector2.down * walkSpeed;
        yield return new WaitForSeconds(walkTime);
    }

    IEnumerator Jump()
    {
        body.velocity = Vector2.up * jumpSpeed;
        yield return new WaitForSeconds(jumpTime);
    }
}
