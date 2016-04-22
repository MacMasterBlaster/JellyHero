using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour {

	public float speed = 2;
	private Rigidbody2D _body;
    private Animator animator;

	public Rigidbody2D body {
		get {
			return _body;
		}
	}

	private Vector2 heading;

	void Awake () {
		_body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        animator.SetFloat("directionX", 0);
        animator.SetFloat("directionY", -1);
    }

	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("attack");
        }

		float x = Input.GetAxis("Horizontal") ;
		float y = Input.GetAxis("Vertical") ;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            y = 0;
            animator.SetFloat("directionX", Mathf.Sign(x));
            animator.SetFloat("directionY", 0);
        }
        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            x = 0;
            animator.SetFloat("directionY", Mathf.Sign(y));
            animator.SetFloat("directionX", 0);
        }
        else
        {
            x = 0;
        }

        body.velocity = new Vector2(x, y) * speed;
        animator.SetFloat("speed", body.velocity.magnitude);
        if (body.velocity.magnitude > 0.1f)
        {
            animator.SetFloat("velocityX", body.velocity.x);
            animator.SetFloat("velocityY", body.velocity.y);

        }
	}
  /*  void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        body.velocity = new Vector2(x, y) * speed;
        animator.SetFloat("speed", body.velocity.magnitude);
        if (body.velocity.magnitude > 0.1f)
        {
            animator.SetFloat("velocityX", x);
            animator.SetFloat("velocityY", y);

            animator.SetFloat("directionX", x);
            animator.SetFloat("directionY", y);

        }
    }
    */
}
