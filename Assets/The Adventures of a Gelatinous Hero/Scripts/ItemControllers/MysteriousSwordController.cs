using UnityEngine;
using System.Collections;

public class MysteriousSwordController : DirectionalComponent {

    public bool isBladePresent = false;
    public bool isGripPresent = false;
    public bool isCrossGuardPesent = false;
    public bool isPommelPresent = false;

    public float stabInterval = .5f;
    public float slashTime = 1.5f;
    public float slashSpread = 15f;

    public SpriteRenderer blade;
    public SpriteRenderer grip;
    public SpriteRenderer crossGuard;
    public SpriteRenderer pommel;

    private Damage _damCol;
    public Damage dc
    {
        get
        {
            if (_damCol == null)
            {
                _damCol = GetComponent<Damage>();
            }
            return _damCol;
        }
    }

    private BoxCollider2D _bCollider;
    public BoxCollider2D bc
    {
        get
        {
            if (_bCollider == null)
            {
                _bCollider = GetComponent<BoxCollider2D>();
            }
            return _bCollider;
        }
    }

    private Vector2 currentDir = Vector2.zero;
    protected float angle = 0f;
    private bool isAnimating = false;
    
    void Awake()
    {
        DisableSword();
        SetDown();
    }

    public void EnableSword()
    {
        isAnimating = true;
        if (isBladePresent)
        {
            blade.enabled = true;
            bc.enabled = true;
        }
        if (isGripPresent) grip.enabled = true;
        if (isCrossGuardPesent) crossGuard.enabled = true;
        if (isPommelPresent) pommel.enabled = true; 
    }

    public void DisableSword()
    {
        isAnimating = false;
        blade.enabled = false;
        grip.enabled = false;
        crossGuard.enabled = false;
        pommel.enabled = false;
        bc.enabled = false;
    }

    public void StabAttack()
    {
        StartCoroutine("StabAttackCoroutine");
    }

    public void SlashAttack()
    {
        StartCoroutine("SlashAttackCoroutine");
    }

    [ContextMenu("Attack Left")]
    protected override void SetLeft()
    {
        currentDir = Vector2.left;
        SetDir();
    }

    [ContextMenu("Attack Right")]
    protected override void SetRight()
    {
        currentDir = Vector2.right;
        SetDir();
    }

    [ContextMenu("Attack Up")]
    protected override void SetUp()
    {
        currentDir = Vector2.up;
        SetDir();
    }

    [ContextMenu("Attack Down")]
    protected override void SetDown()
    {
        currentDir = Vector2.down;
        SetDir();
    }

    void SetDir ()
    {
        if (isAnimating) return;
        angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator StabAttackCoroutine()
    {
        EnableSword();
        angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        yield return new WaitForSeconds(stabInterval);
        DisableSword();
    }

    IEnumerator SlashAttackCoroutine()
    {
        EnableSword();
        angle = Mathf.Atan2(currentDir.y, currentDir.x) * Mathf.Rad2Deg;

        float spread = slashSpread;

        if (currentDir.y == 0)
        {
            spread *= -currentDir.x;
        }
                
        float startAngle = angle - spread;
        float endAngle = angle + spread;

        for (float t = 0; t < slashTime; t += Time.deltaTime)
        {
            float frac = t / slashTime;
            float ang = Mathf.Lerp(startAngle, endAngle, frac);
            transform.localRotation = Quaternion.AngleAxis(ang, Vector3.forward);
            yield return new WaitForEndOfFrame();
        }
        DisableSword();
    }

}
