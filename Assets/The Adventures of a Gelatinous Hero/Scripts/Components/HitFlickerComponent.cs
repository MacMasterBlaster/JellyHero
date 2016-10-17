using UnityEngine;
using System.Collections;

public class HitFlickerComponent : MonoBehaviour {
    public float duration = 0.3f;
    public int numberOfFlickers = 5;
    public Color flickerColor = new Color(255, 0, 0, 255);
    protected Color baseColor;

    public HealthController healthController;

    public SpriteRenderer sr {
        get {
            if (_sr == null) {
                _sr = GetComponent<SpriteRenderer>();
            }
            return _sr;
        }
    }

    private SpriteRenderer _sr;

    void Awake() {
        if (healthController == null) {
            healthController = GetComponent<HealthController>();
        }
        baseColor = sr.color;
    }

    void OnEnable() {
        healthController.onHealthChanged += OnHealthChanged;
    }

    void OnDisable() {
        healthController.onHealthChanged -= OnHealthChanged;
    }

    public void Flicker() {
        StartCoroutine("FlickerCoroutine");
    }

    IEnumerator FlickerCoroutine() {
        int numFlickers = 10;
        for (int i = 0; i < numFlickers; i++)
        {   //alternates color
            sr.color = (i % 2 == 0) ? flickerColor : baseColor;
            yield return new WaitForSeconds(duration / (float)numFlickers);
        }
    }

    void OnHealthChanged(float health, float prevHealth, float maxHealth) {
        if (health < prevHealth)
        {
            Flicker();
        }
    }
}
