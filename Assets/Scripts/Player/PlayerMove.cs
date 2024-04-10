using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Rigidbody rb;
    float move;
    Vector2 mouse;

    [SerializeField] float mousePos;

    [Header("Velocidade de manobra")]
    [SerializeField] float moveForce;
    [SerializeField] float sideForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Inputs();
        rb.MoveRotation(rb.rotation * Quaternion.Euler(mouse.x * sideForce, 0, 0));
        rb.AddRelativeForce(Vector3.up * move * moveForce);
    }

    private void Update()
    {
        mousePos = mouse.x;        
    }

    void Inputs()
    {
        move = input.FindActionMap("Player").FindAction("move").ReadValue<float>();
        mouse = input.FindActionMap("Player").FindAction("mouse").ReadValue<Vector2>();
    }
}
