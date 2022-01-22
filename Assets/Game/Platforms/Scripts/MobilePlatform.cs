using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : Platform
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float _speed;
    private float _acceleraion;
    private Vector3 _targetPosition;
    private void Awake()
    {
        _acceleraion = _speed / 100;        
    }
    private void Update()
    {
        if (transform.position.x == _targetPosition.x) _targetPosition.x = -_targetPosition.x;
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, _targetPosition, _speed);
        rb.MovePosition(nextPosition);
    }
    public void Initialize(float limit)
    {

        _targetPosition = new Vector3( limit,transform.position.y, transform.position.z);
        Debug.Log(_targetPosition);
    }
    override public void IncreaseTemp(float pace)
    {
        _speed = _acceleraion * (pace + 100);
    }
    public override void Onrespawn()
    {
        _targetPosition = new Vector3(_targetPosition.x, transform.position.y, transform.position.z);
    }
}
