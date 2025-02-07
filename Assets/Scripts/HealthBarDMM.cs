using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBarDMM : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    Dmgable demonDmgable;

    private void Awake()
    {
        GameObject demon = GameObject.FindGameObjectWithTag("Demonnnn");

        if (demon == null)
        {
            Debug.Log("No demon found in the scene. Make sure it has tag 'Demonnnn'");
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
        demonDmgable.healthChanged.AddListener(OnDemonnnnHealthChanged);
    }

    private void OnDisable()
    {
        demonDmgable.healthChanged.RemoveListener(OnDemonnnnHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnDemonnnnHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
    }
}
