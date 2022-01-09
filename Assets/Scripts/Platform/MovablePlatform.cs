using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : Platform
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float speed;
    private float acceleraion;
    private Vector3 targetPosition;
    private void Awake()
    {
        acceleraion = speed / 100;        
    }
    private void Update()
    {
        if (transform.position.x == targetPosition.x) targetPosition.x = -targetPosition.x;
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, targetPosition, speed);
        rb.MovePosition(nextPosition);
    }
    public void init(float limit)
    {
        targetPosition = new Vector3( limit,transform.position.y, transform.position.z);
    }
    override public void IncreaseTemp(float pace)
    {
        speed = acceleraion * (pace + 100);
    }
    public override void OnRespawn()
    {
        targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
    }
}
