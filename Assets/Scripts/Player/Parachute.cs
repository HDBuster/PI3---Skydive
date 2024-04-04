using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Parachute : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Rigidbody rb;

    [SerializeField] [Range(1, 5)] float parachuteDrag;

    public bool isParachuteOn = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (input.FindActionMap("Player").FindAction("parachute").ReadValue<float>() == 1)
        {
            rb.drag = parachuteDrag;
            isParachuteOn = true;
        }
    }
}
