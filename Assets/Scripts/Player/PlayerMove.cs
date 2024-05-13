using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Rigidbody rb;
    Vector2 move;
    Vector2 mouse;

    [Header("Stats")]
    [SerializeField] float fallSpeed;
    [SerializeField] float mousePos;

    [Header("Maneuver Speed")]
    [SerializeField] float forwardForce;
    [SerializeField] float sideForce;
    [SerializeField] float lookSpeed;

    PlayerMachineStates.State state;

    void StateFalling()
    {
        switch (state)
        {
            case PlayerMachineStates.State.Flat:
                rb.AddRelativeForce(Vector3.forward * sideForce * move.x); // Move sideways
                rb.AddRelativeForce(Vector3.up * forwardForce); //Move forward
                rb.drag = 1;
                break;
            case PlayerMachineStates.State.Angle:
                rb.AddRelativeForce(Vector3.up * forwardForce * 4); //Move forward
                rb.drag = 0.75f;
                break;
            case PlayerMachineStates.State.HeadDown:
                rb.drag = 0.25f;
                break;
            case PlayerMachineStates.State.Parachute:
                rb.AddRelativeForce(Vector3.up * (forwardForce * 7)); //Move foward faster
                rb.drag = 1.5f;
                break;
        }
    }

    void FixedUpdate() //Update physics
    {
        Inputs();
        StateFalling();

        //Rotate by looking around
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 0, mouse.x * lookSpeed));
    }

    void Update() //Update everthing else
    {
        state = GetComponent<PlayerMachineStates>().state;

        mousePos = mouse.x;
        fallSpeed = rb.velocity.y;
    }

    void Inputs() // Get input
    {
        move = input.FindActionMap("Player").FindAction("move").ReadValue<Vector2>();
        mouse = input.FindActionMap("Player").FindAction("mouse").ReadValue<Vector2>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
