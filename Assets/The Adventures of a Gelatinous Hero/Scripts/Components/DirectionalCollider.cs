using UnityEngine;
using UnityEditor;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DirectionalCollider : DirectionalComponent{

    public Vector2 leftAttackOffset = new Vector2(0, 0);
    public Vector2 leftAttackSize = new Vector2(1, 1);

    public Vector2 rightAttackOffset = new Vector2(0, 0);
    public Vector2 rightAttackSize = new Vector2(1, 1);

    public Vector2 upAttackOffset = new Vector2(0, 0);
    public Vector2 upAttackSize = new Vector2(1, 1);

    public Vector2 downAttackOffset = new Vector2(0, 0);
    public Vector2 downAttackSize = new Vector2(1, 1);

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

    [ContextMenu("Left Collider")]
    protected override void SetLeft()
    {
        bc.offset = leftAttackOffset;
        bc.size = leftAttackSize;
    }

    [ContextMenu("Right Collider")]
    protected override void SetRight()
    {
        bc.offset = rightAttackOffset;
        bc.size = rightAttackSize;
    }

    [ContextMenu("Up Collider")]
    protected override void SetUp()
    {
        bc.offset = upAttackOffset;
        bc.size = upAttackSize;
    }

    [ContextMenu("Down Collider")]
    protected override void SetDown()
    {
        bc.offset = downAttackOffset;
        bc.size = downAttackSize;
    }
}
