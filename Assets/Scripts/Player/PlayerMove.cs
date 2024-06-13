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
    [SerializeField] GameObject cameraa;

    [Header("Stats")]
    [SerializeField] float fallSpeed;
    [SerializeField] float mousePos;

    [Header("Maneuver Speed")]
    [SerializeField] float forwardForce;
    [SerializeField] float sideForce;
    [SerializeField] float lookSpeed;

    [Header("Vertical Speed")]
    [SerializeField] float flatSpeed;
    [SerializeField] float angleSpeed;
    [SerializeField] float headSpeed;
    [SerializeField] float parachuteSpeed;

    PlayerMachineStates.State state;

    void StateFalling()
    {
        switch (state)
        {
            case PlayerMachineStates.State.Flat:
                rb.AddRelativeForce(Vector3.forward * sideForce * move.x); // Move sideways
                rb.AddRelativeForce(Vector3.forward * forwardForce); //Move forward
                rb.AddRelativeForce(-Vector3.up * flatSpeed); //Fall down
                //rb.drag = 1;
                break;
            case PlayerMachineStates.State.Angle:
                rb.AddRelativeForce(Vector3.forward * forwardForce * 4); //Move forward
                rb.AddRelativeForce(-Vector3.up * angleSpeed); //Fall down
                //rb.drag = 0.75f;
                break;
            case PlayerMachineStates.State.HeadDown:
                rb.AddRelativeForce(Vector3.forward * forwardForce * 2); //Move forward
                rb.AddRelativeForce(-Vector3.up * headSpeed); //Fall down
                //rb.drag = 0.25f;
                break;
            case PlayerMachineStates.State.Parachute:
                rb.AddRelativeForce(Vector3.forward * (forwardForce * 7)); //Move foward faster
                //rb.AddRelativeForce(-Vector3.up * parachuteSpeed); //Fall down
                //rb.drag = 1.5f;
                break;
        }
    }

    void FixedUpdate() //Update physics
    {
        Inputs();
        StateFalling();

        //Rotate by looking around
        /*switch (state)
        {
            case PlayerMachineStates.State.Flat:
            case PlayerMachineStates.State.Angle:
            case PlayerMachineStates.State.HeadDown:
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, mouse.x * lookSpeed, 0));
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                break;
            case PlayerMachineStates.State.Parachute:
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0, mouse.x * lookSpeed, 0));
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                break;
        }*/

        //rb.MoveRotation(rb.rotation * Quaternion.Euler(0, mouse.x * lookSpeed, 0));
        rb.MoveRotation(Quaternion.Euler(rb.rotation.eulerAngles.x, (mouse.x * lookSpeed) + rb.rotation.eulerAngles.y, rb.rotation.eulerAngles.z));

        //Camera
        switch (state){
            case PlayerMachineStates.State.Flat:
                //cameraa.transform.localPosition = new Vector3 (0, 0, -50);
                cameraa.transform.localPosition = Vector3.Lerp(cameraa.transform.localPosition, new Vector3(0, 60, 0), 0.05f);
                //cameraa.transform.Translate(new Vector3(0,10,0), Space.Self);
                break;
            case PlayerMachineStates.State.Angle:
                //cameraa.transform.localPosition = new Vector3(0, -3, -75);
                cameraa.transform.localPosition = Vector3.Lerp(cameraa.transform.localPosition, new Vector3(0, 90, -5), 0.05f);
                //cameraa.transform.Translate(new Vector3(0, 15, 1), Space.Self);
                break;
            case PlayerMachineStates.State.HeadDown:
                //cameraa.transform.localPosition = new Vector3(0, -5, -100);
                cameraa.transform.localPosition = Vector3.Lerp(cameraa.transform.localPosition, new Vector3(0, 120, -5), 0.05f);
                //cameraa.transform.Translate(new Vector3(0, 20, 2), Space.Self);
                break;
            case PlayerMachineStates.State.Parachute:
                cameraa.transform.localPosition = Vector3.Lerp(cameraa.transform.localPosition, new Vector3(0, 100, -25), 0.05f);

                /*cameraa.transform.localPosition = Vector3.Lerp(cameraa.transform.localPosition, new Vector3(0, 80, -45), 0.05f);
                cameraa.transform.localRotation = Quaternion.AngleAxis(30, Vector3.down);*/
                //cameraa.transform.localRotation = Quaternion.Euler(Vector3.Lerp(cameraa.transform.rotation.eulerAngles, new Vector3(30, 0, 0), 0.05f));

                //cameraa.transform.localRotation = Quaternion.Euler(Vector3.Lerp(cameraa.transform.rotation.eulerAngles,new Vector3(40,0,0),0.05f));
                //cameraa.transform.localEulerAngles = Vector3.Lerp(cameraa.transform.localEulerAngles, new Vector3(-60, 0, 0), 0.05f);
                //cameraa.transform.localRotation = Quaternion.Euler(-60, 0, 0);
                //cameraa.transform.localRotation = Quaternion.Euler(new Vector3(mouse.x, -60, 0));
                break;
        }


        //cameraa.transform.position = this.transform.position + new Vector3(-10,10,-10);
        //cameraa.transform.Translate(this.transform.position);
        //cameraa.transform.Rotate(0, mouse.x * lookSpeed, 0);
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
        //cameraa.transform.position = this.transform.position;
    }
}
