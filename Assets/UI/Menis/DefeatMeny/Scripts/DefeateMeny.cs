using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeateMeny : MonoBehaviour
{
    [SerializeField] private UIEvents UIEvents;
    // Start is called before the first frame update
    void Start()
    {
        UIEvents.OnPlayerDied.AddListener(TurnOn);
        gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMeny()
    {
        SceneManager.LoadScene(0);
    }
}
