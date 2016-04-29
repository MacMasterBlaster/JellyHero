using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
public class SwitchController : MonoBehaviour {

    private BoxCollider2D _boxCollider;

    public Sprite spriteOn;
    public Sprite spriteOff;
        
    public bool isSwitchOn = false;

    public BoxCollider2D bc
    {
        get
        {
            if (_boxCollider == null)
            {
                _boxCollider = GetComponent<BoxCollider2D>();
            }
            return _boxCollider;
        }
    }

    void Start()
    {
        SetSwitchSprite();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("touch");
        if (collider.tag == "Player")
        {
            isSwitchOn = !isSwitchOn;
            
            SetSwitchSprite();
        }
    }


    public bool CheckSwitchState()
    {
        return isSwitchOn;
    }

    private void SetSwitchSprite()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (isSwitchOn)
        {
            spriteRenderer.sprite = spriteOn;
        }
        else
        {
            spriteRenderer.sprite = spriteOff;
        }
    }
}
