using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] float speedIncreaseTime;
    void Awake()
    {
        PauseMeny pauseMeny = FindObjectOfType<PauseMeny>();
        MapEvent.OnGameStoped.AddListener(pauseMeny.OnGameStoped);
        MapEvent.OnGameContinued.AddListener(pauseMeny.OnGameContinue);
        MapEvent.OnPlayerDied.AddListener(FindObjectOfType<DefeateMeny>().OnDefeat);
        MapEvent.OnIncreasePace.AddListener(FindObjectOfType<SpawnerPlatforms>().OnIncreasePace);
        StartCoroutine(IncreasePace());

    }
    private void Start()
    {
        MapEvent.SendGameStoped();        
    }
    private IEnumerator IncreasePace()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncreaseTime);
            MapEvent.SendIncreaseTime();
        }
    }
}
