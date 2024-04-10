using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMachineStates : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Vector2 move;
    float parachute;

    public enum State {Flat, Angle, HeadDown, Parachute, Land }
    public State state = State.Angle;

    void Update()
    {
        SwitchState();
    }

    void SwitchState()
    {
        switch (state)
        {
            case State.Flat:        FlatState();        break;
            case State.Angle:       AngleState();       break;
            case State.HeadDown:    HeadDownState();    break;
            case State.Parachute:   ParachuteState();   break;
            case State.Land:        LandState();        break;
        }
    }

    void FlatState()
    {
        //actions

        //transitions
        if (move.y == 0)
        {
            state = State.Angle;
        }
        else if (parachute == 1)
        {
            state = State.Parachute;
        }
    }

    void AngleState()
    {
        //actions

        //transitions
        if (move.y == 1)
        {
            state = State.HeadDown;
        }
        else if (move.y == -1)
        {
            state = State.Flat;
        }
        else if (parachute == 1)
        {
            state = State.Parachute;
        }
    }

    void HeadDownState()
    {
        //actions

        //transitions
        if (move.y == 0)
        {
            state = State.Angle;
        }
        else if (parachute == 1)
        {
            state = State.Parachute;
        }
    }

    void ParachuteState()
    {
        //actions

        //transitions
    }

    void LandState()
    {
        //actions

        //transitions
    }

    private void FixedUpdate()
    {
        Inputs();
    }

    void Inputs()
    {
        move = input.FindActionMap("Player").FindAction("move").ReadValue<Vector2>();
        parachute = input.FindActionMap("Player").FindAction("parachute").ReadValue<float>();
    }
}
