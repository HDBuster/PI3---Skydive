using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1;
    }
}
