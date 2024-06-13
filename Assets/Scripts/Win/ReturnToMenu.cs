using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] GameObject pause;
    [SerializeField] GameObject options;

    public void Return()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }

    public void ReturnToPause()
    {
        pause.SetActive(true);
        options.SetActive(false);
    }

    public void GoToOptions()
    {
        pause.SetActive(false);
        options.SetActive(true);
    }
}
