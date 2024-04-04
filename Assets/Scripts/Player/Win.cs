using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    Rigidbody rb;

    public bool playerWin = false;

    bool parachuteCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        parachuteCheck = this.GetComponent<Parachute>().isParachuteOn;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinFinish") && parachuteCheck)
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
