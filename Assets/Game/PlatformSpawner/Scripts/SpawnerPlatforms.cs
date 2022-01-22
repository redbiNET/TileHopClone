using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class SpawnerPlatforms : ScriptableObject
{
    [SerializeField] private StaticPlatform _staticPlatform;
    [SerializeField] private MobilePlatform _mobilePlatform;
    private Platform _lastPlatform;

    [SerializeField] private Queue<Platform> _pool;

    [SerializeField] float _poolSize;

    [SerializeField] private Vector2 _spawnLimit;
    private Vector2 _placementFactor => _spawnLimit / 100;
    private Vector2 _lastPosition;
    // Start is called before the first frame update
    
    public List<Platform> Initialize()
    {
        _lastPosition = Vector2.zero;
        SetPool();
        return new List<Platform>(_pool);
    }
    private void SetPool()
    {
        _pool = new Queue<Platform>();
        for (int i = 0; i < _poolSize; i++)
        {
            CreatePlatform(_staticPlatform);
        }
    }
    public Platform CreatePlatform(Platform platform)
    {
        Platform createdPlatform = Instantiate(platform.gameObject,GetRandomPosition(),Quaternion.identity).GetComponent<Platform>();
        _pool.Enqueue(createdPlatform);
        return createdPlatform;
    }
    public Platform CreatePlatform(TipePlatform tipePlatform)
    {
        Platform platform;
        switch (tipePlatform)
        {
            case TipePlatform.Mobile:
                MobilePlatform createdPlatform = Instantiate(_mobilePlatform, GetRandomPosition(), Quaternion.identity).GetComponent<MobilePlatform>();
                createdPlatform.Initialize(_spawnLimit.x);
                platform = createdPlatform;
                break;
            case TipePlatform.Static:
                platform = Instantiate(_staticPlatform, GetRandomPosition(), Quaternion.identity).GetComponent<MobilePlatform>();
                break;
            default: return null;
        }
        _pool.Enqueue(platform);
        return platform;
    }
    private void RespawnPlatform(Platform platform)
    {
        platform.Respawn(GetRandomPosition()); 
        _pool.Enqueue(platform);
    }
    private Vector3 GetRandomPosition()
    {
        float z = Random.Range(20,101);
        float x = Random.Range(-100,101) * _placementFactor.x;
        float xLimit = (_placementFactor.x * z)*2;
        x = Mathf.Clamp(x,_lastPosition.x - xLimit, _lastPosition.x + xLimit);
        z = 2 + _lastPosition.y + _placementFactor.y * z;
        _lastPosition.x = x;
        _lastPosition.y = z;

        return new Vector3(x, 0, z);

    }
    public Platform Get()
    {

        Platform platform = _pool.Dequeue();
        if(_lastPlatform)
        RespawnPlatform(_lastPlatform);
        _lastPlatform = platform;
        return platform;
    }

}
public enum TipePlatform 
{ 
    Static,
    Mobile
}

