using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Platform : MonoBehaviour
{
    virtual public void Onrespawn()
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
        Onrespawn();
    }
    virtual public void IncreaseTemp(float pace) { }
}
