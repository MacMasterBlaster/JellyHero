using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthUIController : MonoBehaviour {

    public Gradient healthGradient;
    public Image healthSliderFillImage;
    public Text healthText;
    public Slider healthSlider;
    public string tagName = "Player";

    void OnEnable()
    {
        healthSliderFillImage.color = healthGradient.Evaluate(1);
        HealthController.onAnyHealthChanged += UpdateUI;
    }

    //prevents the script from calling this function when it is disabled.
    void OnDisable()
    {
        HealthController.onAnyHealthChanged -= UpdateUI;
    }

    void UpdateUI (HealthController healthController, float health, float prevHealth, float maxHealth)
    {
        if (healthController.gameObject.tag == tagName)
        {
            //healthText.text = tagName + " Health: " + health;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
            healthSliderFillImage.color = healthGradient.Evaluate(health / maxHealth);
        }
    }
}
