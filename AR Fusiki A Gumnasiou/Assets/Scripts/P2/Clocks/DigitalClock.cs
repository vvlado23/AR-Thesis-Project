using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] TextMeshPro timeText;

    public bool timeStoped = true;

    protected float time = 0f;
    protected int seconds = 0;
    protected int newSeconds = 0;
    protected int newMinutes = 0;
    protected int milliseconds = 0;

    protected virtual void Start()
    {
        ResetTime();
    }

    void Update()
    {
        if(!timeStoped)
        {
            time += Time.deltaTime;
            seconds = Mathf.FloorToInt(time);
            milliseconds = (int)((time - seconds) * 1000);

            CountTime();
        }
    }

    public void ResetTime()
    {
        time = 0;
        seconds = 0;
        milliseconds = 0;
        CountTime();
        timeStoped = true;
    }

    public void StopTime()
    {
        timeStoped = true;
    }

    public void StartTime()
    {
        ResetTime();
        timeStoped = false;
    }

    protected virtual void CountTime()
    {
        CalculateMinSec();
        timeText.text = newMinutes + " : " + newSeconds + " : " + milliseconds;
    }

    protected void CalculateMinSec()
    {
        newSeconds = seconds % 60;
        newMinutes = seconds / 60;
    }
}
