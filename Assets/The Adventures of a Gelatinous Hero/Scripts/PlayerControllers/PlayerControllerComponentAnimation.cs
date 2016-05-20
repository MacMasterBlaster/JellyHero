﻿using UnityEngine;
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
                dc.direction = new Vector2(x, y);
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

        if (Input.GetButtonDown("sword") /*|| Input.GetKeyDown("Space")*/)
        {
            attackAnim.SlashAttack();
        }
        if (Input.GetButtonDown("bomb"))
        {
            if (InventoryManager.instance.bombCount > 0)
            {
                GameObject bomb = Spawner.Spawn("Bomb");
                bomb.transform.position = attackAnim.transform.position;
                InventoryManager.SubtractFromBombCount(1);
            }
            else
            {
                Debug.Log("No more bombs dummy!!!");
            }
        }
    }
}
