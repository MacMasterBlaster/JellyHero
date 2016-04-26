using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class NoviceAdventurerController : MonoBehaviour {

    public float speed = 1;
    public float chargeSpeed = 1.5f;
    public float timePerDir = 3;
    public float lineOfSightDis = 5;
    public float attackAnimTriggerDist = 1;
    public PlayerControllerComponentAnimation player;
    private Rigidbody2D _body;
    private DirectionalAttackAnimation daAnim;

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
        daAnim = gameObject.GetComponent<DirectionalAttackAnimation>();
    }

    void Start()
    {
        StartCoroutine("PatrolCoroutine");
        StartCoroutine("CheckPlayerRangeCoroutine");
    }

    void Update()
    {
        if (body.velocity.magnitude > 0.1f)
        {
            DirectionalComponent[] directionals = GetComponentsInChildren<DirectionalComponent>();
            foreach (DirectionalComponent dc in directionals)
            {
                dc.direction = body.velocity;
            }
        }

        DirectionalAnimator[] dirAnis = GetComponentsInChildren<DirectionalAnimator>();
        foreach (DirectionalAnimator dirAni in dirAnis)
        {
            if (body.velocity.magnitude < 0.1f)
            {
                dirAni.PlayAnimation("Idle");
            }
            else
            {
                dirAni.PlayAnimation("Walk");
            }
        }
    }

    IEnumerator PatrolCoroutine()
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
            yield return new WaitForSeconds(timePerDir);

        }
    }

    IEnumerator CheckPlayerRangeCoroutine()
    {
        while (enabled)
        {
            if (((Mathf.Abs(player.transform.position.x - this.transform.position.x) < 0.5f) ||
                (Mathf.Abs(player.transform.position.y - this.transform.position.y) < 0.5f)) &&
                ((Vector3.Distance( player.transform.position, this.transform.position))) < lineOfSightDis)
            {
                //Debug.Log("HERE");
                Vector2 attackDir = (Vector2)(player.transform.position - transform.position);
                if (attackDir.magnitude > 0.5f)
                {
                    if (Mathf.Abs(attackDir.x) > Mathf.Abs(attackDir.y))
                    {
                        body.velocity = Vector2.right * Mathf.Sign(attackDir.x) * speed;
                    }
                    else
                    {
                        body.velocity = Vector2.up * Mathf.Sign(attackDir.y) * speed;
                    }
                }
            }

            if ((Vector3.Distance(player.transform.position, this.transform.position)) <= attackAnimTriggerDist)
            {
                daAnim.Attack();
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        body.velocity *= -1;
    }

}