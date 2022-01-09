using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMeny : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnGameStoped()
    {
        gameObject.SetActive(true);
    }
    public void OnGameContinue()
    {
        gameObject.SetActive(false);
    }
}
