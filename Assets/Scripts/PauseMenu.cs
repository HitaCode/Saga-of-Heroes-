using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool isPaused;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;

    void Start()
    {
        ResumeGame();
    }

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void SetVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
