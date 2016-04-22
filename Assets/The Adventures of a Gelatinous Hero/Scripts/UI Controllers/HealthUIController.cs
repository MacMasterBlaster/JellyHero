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
        HealthController.onUpdateHealthEvent += UpdateUI;
    }

    //prevents the script from calling this function when it is disabled.
    void OnDisable()
    {
        HealthController.onUpdateHealthEvent -= UpdateUI;
    }

    void UpdateUI (HealthController healthController)
    {
        if (healthController.gameObject.tag == tagName)
        {
            healthText.text = tagName + " Health: " + healthController.health;
            healthSlider.maxValue = healthController.maxHealth;
            healthSlider.value = healthController.health;
            healthSliderFillImage.color = healthGradient.Evaluate(healthController.HealthPct());
        }
    }
}
