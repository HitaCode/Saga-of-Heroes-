using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarDM : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    Dmgable demonDmgable;

    private void Awake()
    {
        GameObject demon = GameObject.FindGameObjectWithTag("DemonLorrrd");

        if (demon == null)
        {
            Debug.Log("No demon found in the scene. Make sure it has tag 'DemonLorrrd'");
        }
        demonDmgable = demon.GetComponent<Dmgable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(demonDmgable.Health, demonDmgable.MaxHealth);
        healthBarText.text = "HP " + demonDmgable.Health + " / " + demonDmgable.MaxHealth; 
    }

    private void OnEnable()
    {
        demonDmgable.healthChanged.AddListener(OnDemonLorrrdHealthChanged);
    }

    private void OnDisable()
    {
        demonDmgable.healthChanged.RemoveListener(OnDemonLorrrdHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnDemonLorrrdHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
    }
}
