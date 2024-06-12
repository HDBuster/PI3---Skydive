using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameplay : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
