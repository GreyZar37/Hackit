using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class alarm : MonoBehaviour
{
    static public float alarmTimer;
    int minutes;
    int seconds;
    static public bool timerStarted = false;
    public TMP_Text textTimer;



    // Start is called before the first frame update
    void Update()
    {
        if (timerStarted == true)
        {
            alarmTimer -= Time.deltaTime;
            DisplayTimer();
        }
        
    }

    // Update is called once per frame
    void DisplayTimer()
    {
       

        minutes = Mathf.FloorToInt(alarmTimer / 60.0f);
        seconds = Mathf.FloorToInt(alarmTimer - minutes * 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StartTimer()
    {
        timerStarted = true;
    }
    public void StopTimer()
    {
        timerStarted = false;
    }
    public void ResetTimer()
    {
        alarmTimer = 0.0f;
    }
}
