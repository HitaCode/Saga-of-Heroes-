using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthBarText;
    Dmgable playerDmgable;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if(player == null)
        {
            Debug.Log("No player found in the scene. Make sure it has tag 'Player'");
        }

        playerDmgable = player.GetComponent<Dmgable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(playerDmgable.Health, playerDmgable.MaxHealth);
        healthBarText.text = "HP " + playerDmgable.Health + " / " + playerDmgable.MaxHealth; 
    }

    private void OnEnable()
    {
        playerDmgable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDmgable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
    }
}
