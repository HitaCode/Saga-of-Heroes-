using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseChar : MonoBehaviour
{
    public void ChooseScene()
    {
        SceneManager.LoadScene("ChooseCharacter");
    }
    public void ChooseScene2()
    {
        SceneManager.LoadScene("ChooseCharacter2");
    }
    public void ChooseMode()
    {
        SceneManager.LoadScene("ChooseMode");
    }
}
