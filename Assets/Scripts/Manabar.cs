using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Manabar : MonoBehaviour
{
    public Slider manaSlider;
    public TMP_Text manaBarText;
    Mana playerMana;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("No player found in the scene. Make sure it has tag 'Player'");
        }

        playerMana = player.GetComponent<Mana>();
    }
    // Start is called before the first frame update
    void Start()
    {
        manaSlider.value = CalculateSliderPercentage(playerMana.Maana, playerMana.MaxMana);
        manaBarText.text = "MANA " + playerMana.Maana + " / " + playerMana.MaxMana;
    }

    private void OnEnable()
    {
        playerMana.manaChanged.AddListener(OnPlayerManaChanged);
    }

    private void OnDisable()
    {
        playerMana.manaChanged.RemoveListener(OnPlayerManaChanged);
    }

    private float CalculateSliderPercentage(float Maana, float MaxMana)
    {
        return Maana / MaxMana;
    }

    private void OnPlayerManaChanged(int newMana, int MaxMana)
    {
        manaSlider.value = CalculateSliderPercentage(newMana, MaxMana);
        manaBarText.text = "MANA " + newMana + " / " + MaxMana;
    }
}
