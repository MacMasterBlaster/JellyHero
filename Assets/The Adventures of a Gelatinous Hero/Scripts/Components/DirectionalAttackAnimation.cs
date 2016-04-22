using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class DirectionalAttackAnimation : DirectionalComponent {

    public float frameInterval = 0.2f;
    public Sprite[] leftAttackSprites;
    public Sprite[] rightAttackSprites;
    public Sprite[] upAttackSprites;
    public Sprite[] downAttackSprites;

    private Sprite[] currentAttackFrames;
    private SpriteRenderer _spriteRenderer;

    public SpriteRenderer spriteRenderer
    {
        get
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }

    public void Attack()
    {
        StartCoroutine("AttackCoroutine");
    }

    [ContextMenu("Attack Left")]
    protected override void SetLeft()
    {
        currentAttackFrames = leftAttackSprites;
    }

    [ContextMenu("Attack Right")]
    protected override void SetRight()
    {
        currentAttackFrames = rightAttackSprites;
    }

    [ContextMenu("Attack Up")]
    protected override void SetUp()
    {
        currentAttackFrames = upAttackSprites;
    }

    [ContextMenu("Attack Down")]
    protected override void SetDown()
    {
        currentAttackFrames = downAttackSprites;
    }

    IEnumerator AttackCoroutine()
    {
        for (int i = 0; i <= currentAttackFrames.Length; i++)
        { 
            spriteRenderer.sprite = currentAttackFrames[i];
        }
        yield return new WaitForSeconds(frameInterval);
    }
}
