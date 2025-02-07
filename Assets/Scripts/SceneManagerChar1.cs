using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerChar1 : MonoBehaviour
{
    public void FSChar11()
    {
        SceneManager.LoadScene("FirstStory");
    }
    public void SSChar11()
    {
        SceneManager.LoadScene("SecondStory");
    }
    public void TSChar11()
    {
        SceneManager.LoadScene("ThirdStory");
    }
    public void FFSChar11()
    {
        SceneManager.LoadScene("FourthStory");
    }
    public void Winpoint()
    {
        SceneManager.LoadScene("YouWinScene");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartAgainGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void StartAgainGame2()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void StartAgainGame3()
    {
        SceneManager.LoadScene("Level_3");
    }
    public void StartAgainGame4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Choosemap1()
    {
        SceneManager.LoadScene("ChooseMap");
    }
    public void ChooseChallenge()
    {
        SceneManager.LoadScene("ChallengeMap");
    }
}
