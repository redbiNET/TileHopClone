using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class CharacterController : MonoBehaviour
{ 
    [SerializeField] private SpawnerPlatforms spawner;
    [SerializeField] private AnimationCurve jumpCurve;
    private SwipeHandler swipeHandler;

    [SerializeField] private float HorizontalLimit;

    private float distanse = 0.5f;
    private float coveredDistanse;

    [SerializeField] private float speed;
    private float acceleration;

    Rigidbody rb;

    private UnityEvent OnLanded = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        acceleration = speed / 100;
        rb = GetComponent<Rigidbody>();
        swipeHandler = FindObjectOfType<SwipeHandler>();

        MapEvent.OnPlayerDied.AddListener(OnDie);
        MapEvent.OnIncreasePace.AddListener(OnIncreasePace);
        OnLanded.AddListener(FindObjectOfType<LandingCounter>().OnLanded);
    }
    private void Update()
    {
        if (transform.position.y < -0.2f) 
        { 
            MapEvent.SendPlayerDied();
        } 
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        coveredDistanse += speed / distanse;
        float y = jumpCurve.Evaluate(coveredDistanse) * distanse;

        Vector3 nextPosition = new Vector3(swipeHandler.controllerOnScreen * HorizontalLimit, y, transform.position.z + speed);
        rb.MovePosition(nextPosition);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Platform platform = spawner.GetNextPlatform();
        distanse = platform.transform.position.z - transform.position.z;
        coveredDistanse = 0;
        OnLanded.Invoke();
    }
    public void OnDie()
    {
        gameObject.SetActive(false);
    }
    private void OnIncreasePace()
    {
        speed += acceleration;
    }
}
