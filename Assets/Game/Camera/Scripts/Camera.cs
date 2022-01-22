using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _zOffSet;
    private void Start()
    {
        _zOffSet = transform.position.z + _target.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z + _zOffSet);
    }
}
