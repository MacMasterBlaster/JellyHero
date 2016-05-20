using UnityEngine;
using System.Collections;
using Paraphernalia.Components;
using Paraphernalia.Utils;

public class OlafController : MonoBehaviour
{
    public float walkSpeed = 1;
    public float jumpSpeed = 10;
    public float attackInterval = 5;
    public float walkTime = 5;
    public float jumpTime = 5;
    public float waitTime = 2;
    public float agroHealth = 5;

    public string jumpSoundName;
    public string landingSoundName;
    public string footStepName;
    public string[] hurtSoundNames;
    public string[] attackSoundNames;

    private Rigidbody2D _body;
    private Animator animator;
    private HealthController healthController;
    private string hurt;
    private string swipe;

    public Rigidbody2D body
    {
        get
        {
            return _body;
        }
    }

    void Awake()
    {
        hurt = hurtSoundNames[Random.Range(0, hurtSoundNames.Length)];
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
        if (healthController.health <= agroHealth)
        {
            animator.SetTrigger("Swing");
        }
        else
        {
            animator.SetTrigger("Thrust");
            animator.SetTrigger("Agro");
        }
    }

    public void Jump ()
    {
        AudioManager.PlayEffect(jumpSoundName);
        body.velocity = Vector2.up * jumpSpeed;
    }

    public void PlayFootStep()
    {
        AudioManager.PlayVariedEffect(footStepName);
    }

    public void PlayAttackSound()
    {
        swipe = attackSoundNames[Random.Range(0, attackSoundNames.Length)];
        AudioManager.PlayEffect(swipe);
    }

    public void PlayLandingSound()
    {
        AudioManager.PlayEffect(landingSoundName);
    }
}
