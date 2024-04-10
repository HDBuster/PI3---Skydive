using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    Rigidbody rb;
    PlayerMachineStates.State state;

    public bool playerWin = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        state = GetComponent<PlayerMachineStates>().state;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinFinish") && state == PlayerMachineStates.State.Parachute)
        {
            playerWin = true;
            WinScene();
        }
    }

    private void WinScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
