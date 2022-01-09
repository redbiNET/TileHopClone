using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnerPlatforms : MonoBehaviour
{
    [SerializeField] private StaticPlatform staticPlatform;
    [SerializeField] private MovablePlatform movablePlatform;
    [SerializeField] private Platform LastPlatform;

    [SerializeField] private Queue<Platform> pool = new Queue<Platform>();

    [SerializeField] float poolSize;
    private float pace;

    [SerializeField] private Vector2 spawnlimit;
    private Vector2 lastPosition = Vector2.zero;

    private UnityEvent<float> OnIncreaseSpeed = new UnityEvent<float>();
    // Start is called before the first frame update
    private void Awake()
    {
        spawnlimit /= 100;
        SetPool();
    }
    private void SetPool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreatePlatform<Platform>(staticPlatform);
        }
    }
    private T CreatePlatform<T>(T platform) where T : Platform
    {
        T obj = Instantiate(platform.gameObject).GetComponent<T>();
        obj.transform.position = RandomPlaising();
        OnIncreaseSpeed.AddListener(obj.IncreaseTemp);
        pool.Enqueue(obj);
        return obj;
    }
    private void ReSpawnPlatform(Platform obj)
    {
        obj.Respawn(RandomPlaising()); 
        pool.Enqueue(obj);
    }
    private Vector3 RandomPlaising()
    {
        float z = Random.Range(20,101);
        float x = Random.Range(-100,101) * spawnlimit.x;
        float xLimit = (spawnlimit.x * z)*2;
        x = Mathf.Clamp(x,lastPosition.x - xLimit, lastPosition.x + xLimit);
        z = 2 + lastPosition.y + spawnlimit.y * z;
        lastPosition.x = x;
        lastPosition.y = z;
        return new Vector3(x, 0, z);
    }
    public Platform GetNextPlatform()
    {
        Platform obj = pool.Dequeue();
        ReSpawnPlatform(LastPlatform);
        LastPlatform = obj;
        return obj;
    }
    public void OnIncreasePace()
    {
        if(++pace % 100 == 0)
        {
            MovablePlatform obj = CreatePlatform<MovablePlatform>(movablePlatform);
            obj.init(spawnlimit.x * 100);
        }
        OnIncreaseSpeed.Invoke(pace);
    }
}
