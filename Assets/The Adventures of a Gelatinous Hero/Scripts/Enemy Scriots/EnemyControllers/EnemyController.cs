using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class EnemyController : MonoBehaviour {

	public float speed = 1;
    public float timePerDir = 3;
	private Rigidbody2D _body;
    private Animator animator;

	public Rigidbody2D body {
		get {
			return _body;
		}
	}

	void Awake () {
		_body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
	}

    void Start()
    {
        StartCoroutine("RandomMoveCoroutine");
    }

    IEnumerator RandomMoveCoroutine()
    {
        while (enabled)
        {
            Vector2 dir = Random.insideUnitCircle;
            if (dir.magnitude > 0.5f)
            {
                if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                {
                    body.velocity = Vector2.right * Mathf.Sign(dir.x) * speed;
                }
                else
                {
                    body.velocity = Vector2.up * Mathf.Sign(dir.y) * speed;
                }
            }
            else
            {
                body.velocity = Vector2.zero;
            }
            animator.SetFloat("velocityX", body.velocity.x);
            animator.SetFloat("velocityY", body.velocity.y);
            animator.SetFloat("speed", body.velocity.magnitude);
            yield return new WaitForSeconds(timePerDir);

        }
    }
}
