using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class VerticalOrderingController : MonoBehaviour {

    private SpriteRenderer sprite;
    public bool isStatic = true;
    public int offset = 0;
    public int multiplier = 100;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void OnEnable()
    {
        StartCoroutine("UpdateOrderingCoroutine");
    }

    IEnumerator UpdateOrderingCoroutine()
    {
        while (enabled && !isStatic)
        {
            SetOrdering();
            yield return new WaitForEndOfFrame();
        }
    }

    void SetOrdering()
    {
        sprite.sortingOrder = (int)(-transform.position.y * multiplier) + offset;
    }
}
