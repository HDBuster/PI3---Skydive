using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
