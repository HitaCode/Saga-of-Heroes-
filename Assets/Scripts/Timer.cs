using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float timeElapsed = 0f; // Biến để lưu trữ thời gian đã trôi qua
    public TMP_Text timerText; // Tham chiếu đến Text UI để hiển thị thời gian
    private bool timerRunning = true;
    public static float timeCompleted = 0f;
    Dmgable dmgable;
    void Awake()
    {
        // Đảm bảo đối tượng không bị hủy khi chuyển scene
        DontDestroyOnLoad(gameObject);
        dmgable = GetComponent<Dmgable>();
    }
    void Update()
    {
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeElapsed / 60);
            int seconds = Mathf.FloorToInt(timeElapsed % 60);

            if (timerText != null)
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Hiển thị dưới dạng MM:SS
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Dừng bộ đếm và lưu thời gian
            timerRunning = false;
            timeCompleted = timeElapsed;
            // Chuyển sang scene kết quả
            SceneManager.LoadScene("YouWinChallenge"); // Thay "ResultScene" bằng tên scene kết quả của bạn
        }
    }
    // Hàm để reset lại thời gian
    public void ResetTimer()
    {
        timeElapsed = 0f; // Đặt lại thời gian về 0
    }
}
