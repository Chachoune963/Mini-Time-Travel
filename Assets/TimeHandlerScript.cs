using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHandlerScript : MonoBehaviour
{
    private static TimeHandlerScript _instance;
    
    public delegate void TimeTravel(int frames);
    public static event TimeTravel OnTimeTravel;

    public static TimeHandlerScript GetInstance()
    {
        if (_instance == null)
        {
            _instance = new TimeHandlerScript();
        }
        return _instance;
    }

    public static void CallTimeTravelEvent(int frames)
    {
        OnTimeTravel(frames);
    }
}
