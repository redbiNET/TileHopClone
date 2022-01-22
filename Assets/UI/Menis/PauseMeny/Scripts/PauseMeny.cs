using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMeny : MonoBehaviour
{
    [SerializeField] private UIEvents UIEvents;
    // Start is called before the first frame update
    void Start()
    {
        UIEvents.OnGameStoped.AddListener(TurnOn);
        UIEvents.OnGameContinued.AddListener(TurnOff);
        UIEvents.SendGameStoped();
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
