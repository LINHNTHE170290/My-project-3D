using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour // Renamed from Time to Timer to avoid conflict with Unity's Time class
{
    public Text timeText;
    private float startTime;
    //public float activationTime;
    //private bool activationFeature = false;
    private bool isRunning = true; // Cờ để kiểm soát thời gian

    // Start is called before the first frame update
    void Start()
    {
        startTime = UnityEngine.Time.time; // Use full reference to Unity's Time class to avoid ambiguity
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning) return; // Dừng cập nhật thời gian nếu trò chơi kết thúc
        float timePasses = UnityEngine.Time.time - startTime;

        int minutes = (int)(timePasses / 60);
        int seconds = (int)(timePasses % 60);

        // Corrected time format string to display minutes and seconds
        timeText.text = string.Format("{00:00}:{01:00}", minutes, seconds);

        //if (timePasses >= activationTime && !activationFeature)
        //{
            //activationFeature = true;
            
        //}
    }
    public void StopTimer()
    {
        isRunning = false; // Dừng bộ đếm thời gian
    }

    
}
