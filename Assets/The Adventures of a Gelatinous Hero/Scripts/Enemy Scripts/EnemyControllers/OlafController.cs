using UnityEngine;
using System.Collections;

public class OlafController : MonoBehaviour
{

    public float speed = 1;
    public float attackInterval = .3f;
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
    }

    IEnumerator Thrust()
    {
        animator.SetTrigger("Thrust");
        yield return new WaitForSeconds(attackInterval);
    }

    IEnumerator Walk()
    {

        yield return new WaitForSeconds(attackInterval);
    }
}
