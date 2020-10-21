using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class Timer
{
    public static float StartTime;
    public static string timestring;
    public static void Start()
    {
        StartTime = Time.time;
    }
    public static void Update()
    {
        float TimerControl = Time.time - StartTime;
        string mins = ((int)TimerControl / 60).ToString("00");
        string segs = (TimerControl % 60).ToString("00.000");
        //string milisegs = ((TimerControl * 100) % 100).ToString("00");
        timestring = mins + ":" + segs;
        //timestring = string.Format("{00}:{01}:{02}", mins, segs, milisegs);
    }
}