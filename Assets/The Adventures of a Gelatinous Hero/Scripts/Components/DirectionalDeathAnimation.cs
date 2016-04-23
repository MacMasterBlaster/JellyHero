using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class DirectionalDeathAnimation : DirectionalComponent
{

    public float frameInterval = 0.2f;
    public Sprite[] leftDeathSprites;
    public Sprite[] rightDeathSprites;
    public Sprite[] upDeathSprites;
    public Sprite[] downDeathSprites;

    private Sprite[] currentDeathFrames;
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

    public void Die()
    {
        StartCoroutine("DieCoroutine");
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

    IEnumerator DieCoroutine()
    {
        for (int i = 0; i <= currentDeathFrames.Length; i++)
        {
            spriteRenderer.sprite = currentDeathFrames[i];
        }
        yield return new WaitForSeconds(frameInterval);
    }
}
