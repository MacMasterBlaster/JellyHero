using UnityEngine;
using System.Collections;

public class FlickerComponent : MonoBehaviour {
    public float duration = 3;
    int numberOfFlickers = 5;
    public Color flickerColor01 = new Color(255, 255, 255, 255);
    protected Color flickerColor02 = new Color(255, 255, 255, 255);

    private HealthController healthController;

    public SpriteRenderer sr
    {
        get
        {
            if (_sr == null)
            {
                _sr = GetComponent<SpriteRenderer>();
            }
            return _sr;
        }
    }

    private SpriteRenderer _sr;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
    }

    void OnEnable()
    {
        healthController.onHealthChanged += OnHealthChanged;
    }

    void OnDisable()
    {
        healthController.onHealthChanged -= OnHealthChanged;
    }

    public void Flicker()
    {
        StartCoroutine("FlickerCoroutine");
    }

    IEnumerator FlickerCoroutine()
    {
        int numFlickers = 10;
        for (int i = 0; i < numFlickers; i++)
        {   //alternates color
            sr.color = (i % 2 == 0) ? flickerColor01 : flickerColor02;
            yield return new WaitForSeconds(duration / (float)numFlickers);
        }
    }

    void OnHealthChanged(float health, float prevHealth, float maxHealth)
    {
        Flicker();
    }
}
