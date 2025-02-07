using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerChar2 : MonoBehaviour
{
    public void FSChar21()
    {
        SceneManager.LoadScene("FirstStory2");
    }
    public void SSChar21()
    {
        SceneManager.LoadScene("SecondStory2");
    }
    public void TSChar21()
    {
        SceneManager.LoadScene("ThirdStory2");
    }
    public void FFSChar21()
    {
        SceneManager.LoadScene("FourthStory2");
    }
    public void Start2Game()
    {
        SceneManager.LoadScene("Level_1_Character2");
    }
    public void Start2AgainGame()
    {
        SceneManager.LoadScene("Level_1_Character2");
    }
    public void Start2AgainGame2()
    {
        SceneManager.LoadScene("Level_2_Character2");
    }
    public void Start2AgainGame3()
    {
        SceneManager.LoadScene("Level_3_Character2");
    }
    public void Start2AgainGame4()
    {
        SceneManager.LoadScene("Level4_Character2");
    }
    public void Choosemap2()
    {
        SceneManager.LoadScene("ChooseMap2");
    }
    public void ChooseChallenge2()
    {
        SceneManager.LoadScene("ChallengeMap2");
    }
}

