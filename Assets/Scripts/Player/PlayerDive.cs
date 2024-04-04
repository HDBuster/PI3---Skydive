using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDive : MonoBehaviour
{
    [SerializeField] private InputActionAsset input;
    Rigidbody rb;
    float dive;

    [SerializeField] float diveMultiplier;

    [SerializeField] float fallSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        dive = input.FindActionMap("Player").FindAction("dive").ReadValue<float>() * (-1);
        rb.AddForce(new Vector3 (0, dive * diveMultiplier, 0), ForceMode.Force);

        fallSpeed = rb.velocity.y;
    }
}
