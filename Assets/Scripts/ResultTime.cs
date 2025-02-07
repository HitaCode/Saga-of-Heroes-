using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResultTime : MonoBehaviour
{
    public TMP_Text resultText;

    void Start()
    {
        // Hiển thị thời gian hoàn thành trong kết quả
        float time = Timer.timeCompleted; // Lấy thời gian từ Timer
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        resultText.text = string.Format("TIME COMPLETE  {0:00}:{1:00}", minutes, seconds); // Hiển thị kết quả
    }
}
