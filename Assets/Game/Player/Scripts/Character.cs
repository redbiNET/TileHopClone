using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Character : MonoBehaviour
{ 
    [SerializeField] private SpawnerPlatforms _spawner;
    [SerializeField] private AnimationCurve _jumpCurve;
    [SerializeField] private MapEvents _mapEvents;
    [SerializeField] private UIEvents _UIEvents;
    private SwipeHandler _swipeHandler;

    [SerializeField] private float _horizontalLimit;

    private float _distanse = 0.5f;
    private float _coveredDistanse;

    [SerializeField] private float _speed;
    private float _acceleration;

    Rigidbody rb;

    private UnityEvent OnLanded = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        _acceleration = _speed / 100;
        rb = GetComponent<Rigidbody>();
        _swipeHandler = FindObjectOfType<SwipeHandler>();

        _UIEvents.OnPlayerDied.AddListener(OnDie);
        _mapEvents.OnIncreasePace.AddListener(IncreaseSpeed);
        OnLanded.AddListener(FindObjectOfType<LandingCounter>().OnLanded);
    }
    private void Update()
    {
        if (transform.position.y < -0.2f) 
        { 
            _UIEvents.SendPlayerDied();
        } 
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _coveredDistanse += _speed / _distanse;
        float y = _jumpCurve.Evaluate(_coveredDistanse) * _distanse;

        Vector3 nextPosition = new Vector3(_swipeHandler.ControllerOnScreen * _horizontalLimit, y, transform.position.z + _speed);
        rb.MovePosition(nextPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Platform platform = _spawner.Get();
        _distanse = platform.transform.position.z - transform.position.z;
        _coveredDistanse = 0;
        OnLanded.Invoke();
    }
    public void OnDie()
    {
        gameObject.SetActive(false);
    }
    private void IncreaseSpeed(float pace)
    {
        _speed += _acceleration;
    }
}
