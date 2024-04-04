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

    [Header("Velocidade de manobra")]
    [SerializeField] float moveForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        move = input.FindActionMap("Player").FindAction("move").ReadValue<Vector2>();
        rb.velocity = new Vector3((move.y * (-1)) * moveForce, rb.velocity.y, move.x * moveForce);
    }
}
