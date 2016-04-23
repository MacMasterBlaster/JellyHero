using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControllerComponentAnimation : MonoBehaviour
{

    public float speed = 2;
    private Rigidbody2D _body;
    public MysteriousSwordController attackAnim;

    public Rigidbody2D body
    {
        get
        {
            return _body;
        }
    }

    private Vector2 heading;
    void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            y = 0;
        }
        else if (Mathf.Abs(x) < Mathf.Abs(y))
        {
            x = 0;
        }
        else
        {
            x = 0;
        }

        body.velocity = new Vector2(x, y) * speed;
        if (body.velocity.magnitude > 0.1f)
        {
            DirectionalComponent[] directionals = GetComponentsInChildren<DirectionalComponent>();
            foreach (DirectionalComponent dc in directionals)
            {
                dc.SetDirection(new Vector2(x, y));
            }
        }

        DirectionalAnimation[] dirAnis = GetComponentsInChildren<DirectionalAnimation>();
        foreach(DirectionalAnimation dirAni in dirAnis)
        {
            dirAni.speed = body.velocity.magnitude;
        }

        if (Input.GetButtonDown("Jump"))
        {
            attackAnim.StabAttack();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            GameObject bomb = BombManager.SpawnBomb();
            bomb.transform.position = gameObject.transform.position + (Vector3)heading.normalized * 0.5f;
        }
    }
}
