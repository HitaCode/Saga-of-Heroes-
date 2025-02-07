using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackScene : MonoBehaviour
{
    public void OnRetryButtonPressed()
    {
        // Kiểm tra xem biến tĩnh lastScene có chứa tên scene hợp lệ không
        if (!string.IsNullOrEmpty(LosePoint.lastScene))
        {
            // Quay lại scene trước đó
            SceneManager.LoadScene(LosePoint.lastScene);
        }
        if (!string.IsNullOrEmpty(Dmgable.lastScene1))
        {
            // Quay lại scene trước đó
            SceneManager.LoadScene(Dmgable.lastScene1);
        }
    }
}

