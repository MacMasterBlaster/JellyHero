﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class RatController : MonoBehaviour {

    public float speed = 2;
    public float timePerDir = 5;
    public float attackTriggerDist = 0.5f;
    public PlayerControllerComponentAnimation player;
    public Rigidbody2D body
    {
        get
        {
            return _body;
        }
    }

    private int[] nums = new int[]{ -1, 0, 1 };
    private Rigidbody2D _body;
    private DirectionalBoxCollider2D dc;

    void Awake()
    {
        _body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine("PatrolCoroutine");
    }

    void Update () {

        if (Mathf.Abs(body.velocity.magnitude) > 0.1f)
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

        //if ((Vector3.Distance(player.transform.position, this.transform.position)) <= attackTriggerDist)
        //{
        //    //play squeak attack sound
        //}
    }

    IEnumerator PatrolCoroutine()
    {
        while (enabled)
        {
            int x = nums[Random.Range(0, 2)];
            int y = nums[Random.Range(0, 2)];

            body.velocity = new Vector2(x, y);

            yield return new WaitForSeconds(timePerDir);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        body.velocity *= -1;
    }
}