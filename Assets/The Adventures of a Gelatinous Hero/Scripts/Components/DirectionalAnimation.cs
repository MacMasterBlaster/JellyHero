using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class DirectionalAnimation : DirectionalComponent {

    public float speed = 0;
    public float frameInterval = 0.2f;

    public Sprite[] leftIdleSprites;
    public Sprite[] rightIdleSprites;
    public Sprite[] upIdleSprites;
    public Sprite[] downIdleSprites;

    public Sprite[] leftWalkSprites;
    public Sprite[] rightWalkSprites;
    public Sprite[] upWalkSprites;
    public Sprite[] downWalkSprites;

    private Sprite[] currentWalkFrames;
    private Sprite[] currentIdleFrames;
    private int currentFrame = 0;

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

    void OnEnable()
    {
        StartCoroutine("AnimatedCoroutine");
    }

    [ContextMenu("Look Left")]
    protected override void SetLeft()
    {
        currentWalkFrames = leftWalkSprites;
        currentIdleFrames = leftIdleSprites;
        if (!Application.isPlaying)
        {
            spriteRenderer.sprite = leftIdleSprites[0];
        }
    }

    [ContextMenu("Look Right")]
    protected override void SetRight()
    {
        currentWalkFrames = rightWalkSprites;
        currentIdleFrames = rightIdleSprites;
        if (!Application.isPlaying)
        {
            spriteRenderer.sprite = rightIdleSprites[0];
        }
    }

    [ContextMenu("Look Up")]
    protected override void SetUp()
    {
        currentWalkFrames = upWalkSprites;
        currentIdleFrames = upIdleSprites;
        if (!Application.isPlaying)
        {
            spriteRenderer.sprite = upIdleSprites[0];
        }
    }

    [ContextMenu("Look Down")]
    protected override void SetDown()
    {
        currentWalkFrames = downWalkSprites;
        currentIdleFrames = downIdleSprites;
        if (!Application.isPlaying)
        {
            spriteRenderer.sprite = downIdleSprites[0];
        }
    }

    IEnumerator AnimatedCoroutine()
    {
        while (enabled)
        {
            if(speed < 0.1f)
            {
                currentFrame %= currentIdleFrames.Length;
                spriteRenderer.sprite = currentIdleFrames[currentFrame];
                currentFrame++;
            }
            else
            {
                currentFrame %= currentWalkFrames.Length;
                spriteRenderer.sprite = currentWalkFrames[currentFrame];
                currentFrame++;
            }
            yield return new WaitForSeconds(frameInterval);
        }
    }
}
