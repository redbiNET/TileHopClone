using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapEvent : MonoBehaviour
{
    static public UnityEvent OnPlayerDied = new UnityEvent();
    static public UnityEvent OnGameStoped = new UnityEvent();
    static public UnityEvent OnGameContinued = new UnityEvent();
    static public UnityEvent OnIncreasePace = new UnityEvent();

    public static void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
        Time.timeScale = 0;
    }

    public static void SendGameContinued()
    {
        OnGameContinued.Invoke();
        Time.timeScale = 1;
    }
    public static void SendGameStoped()
    {
        OnGameStoped.Invoke();
        Time.timeScale = 0;
    }
    public static void SendIncreaseTime()
    {
        OnIncreasePace.Invoke();
    }
}
