using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu]
public class MapEvents : ScriptableObject
{
     public UnityEvent<float> OnIncreasePace { get; } = new UnityEvent<float>();
    public  void SendIncreaseTime(float pace)
    {
        OnIncreasePace.Invoke(pace);
    }
}
