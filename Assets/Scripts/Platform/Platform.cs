using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Platform : MonoBehaviour
{
    virtual public void OnRespawn()
    {

    }
    public void Respawn(Vector3 position)
    {
        StartCoroutine(WaitForRespawn(position));

    }
    private IEnumerator WaitForRespawn(Vector3 position)
    {
        yield return new WaitForSeconds(1f);
        transform.position = position;
        OnRespawn();
    }
    virtual public void IncreaseTemp(float pace) { }
}
