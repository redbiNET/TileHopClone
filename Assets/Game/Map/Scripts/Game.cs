using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private float _platformAddTime;
    [SerializeField] float _speedIncreaseTime;
    private float _pace;

    [SerializeField] MapEvents _mapEvent;
    [SerializeField] private SpawnerPlatforms _spawnerPlatforms;
    void Awake()
    {
        SetSpawnerPlatforms();
        StartCoroutine(IncreasePace());
    }
    private void SetSpawnerPlatforms()
    {
        List<Platform> platforms = _spawnerPlatforms.Initialize();
        foreach (Platform platform in platforms)
        {
            _mapEvent.OnIncreasePace.AddListener(platform.IncreaseTemp);
        }
    }
    private IEnumerator IncreasePace()
    {
        while (true)
        {
            yield return new WaitForSeconds(_speedIncreaseTime);
            _mapEvent.SendIncreaseTime(++_pace);
            if(++_pace % _platformAddTime == 0)
            {
                Platform platform = _spawnerPlatforms.CreatePlatform(TipePlatform.Mobile);
                _mapEvent.OnIncreasePace.AddListener(platform.IncreaseTemp);
            }
        }

    }
}
