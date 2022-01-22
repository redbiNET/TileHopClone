using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class UIEvents : ScriptableObject
{
    public UnityEvent OnPlayerDied { get; } = new UnityEvent();
    public UnityEvent OnGameStoped { get; } = new UnityEvent();
    public UnityEvent OnGameContinued { get; } = new UnityEvent();

    public void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
        Time.timeScale = 0;
    }

    public void SendGameContinued()
    {
        OnGameContinued.Invoke();
        Time.timeScale = 1;
    }
    public void SendGameStoped()
    {
        OnGameStoped.Invoke();
        Time.timeScale = 0;
    }
}
