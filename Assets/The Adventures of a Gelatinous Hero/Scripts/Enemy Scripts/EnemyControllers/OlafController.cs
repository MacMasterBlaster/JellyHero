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
        StartCoroutine("Pattern1");
    }

    IEnumerator Pattern1()
    {
        Debug.Log("HERE");
        body.velocity = Vector2.down * walkSpeed;
        yield return new WaitForSeconds(walkTime);
        body.velocity = Vector2.zero;
        animator.SetTrigger("Thrust");
    }

    public void Jump ()
    {
        body.velocity = Vector2.up * jumpSpeed;
    }
}
