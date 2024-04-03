using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Rigidbody rb;

    [SerializeField] float moveForce;
    void Start()
    {
        input.FindActionMap("Player").FindAction("move").performed += OnMove;
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        rb.AddForce(new Vector3(context.ReadValue<Vector2>().y * (-1),0, context.ReadValue<Vector2>().x) * moveForce, ForceMode.Impulse);
    }
}
