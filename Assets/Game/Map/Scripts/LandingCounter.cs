using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingCounter : MonoBehaviour
{
    private float _landingCount;
    [SerializeField] private Text text;

    public void OnLanded()
    {
        text.text = $"{_landingCount++}";
    }
}
