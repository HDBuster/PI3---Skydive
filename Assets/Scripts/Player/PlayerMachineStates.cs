using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

public class PlayerMachineStates : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    Vector2 move;
    float parachute;
    [SerializeField] float transitionTime;
    [SerializeField] float animationSpeed;
    [SerializeField] int parachuteHeight;
    bool isParachuteOn;
    bool parachuteOpen;
    [SerializeField] ParachuteDetector parachuteDetector;

    Rigidbody rb;
    MeshRenderer objectParachute;
    [SerializeField]Animator animator;
    [SerializeField] Animator cameraAnimator;
    [SerializeField] AudioSource parachuteHeightBeep;

    public enum State {Flat, Angle, HeadDown, Parachute, Land }
    public State state = State.Angle;

    void Update()
    {
        SwitchState();

        if (transform.position.y <= parachuteHeight + 5 && transform.position.y >= parachuteHeight)
        {
            parachuteHeightBeep.Play();
        }
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
        Animation("Falling");
        CameraAnimation("flat");

        //transitions
        if (move.y == 0)
        {
            state = State.Angle;
        }
        else if (parachute == 1 && rb.position.y <= parachuteHeight)
        {
            state = State.Parachute;
        }
    }

    void AngleState()
    {
        //actions
        Animation("Fast");
        CameraAnimation("angle");

        //transitions
        if (move.y == 1)
        {
            state = State.HeadDown;
        }
        else if (move.y == -1)
        {
            state = State.Flat;
        }
        else if (parachute == 1 && rb.position.y <= parachuteHeight)
        {
            state = State.Parachute;
        }
    }

    void HeadDownState()
    {
        //actions
        Animation("Faster");
        CameraAnimation("headdown");

        //transitions
        if (move.y == 0)
        {
            state = State.Angle;
        }
        else if (parachute == 1 && rb.position.y <= parachuteHeight)
        {
            state = State.Parachute;
        }
    }

    //[SerializeField] AudioClip parachuteAudio;
    [SerializeField] AudioSource parachuteAudio;

    void ParachuteState()
    {
        //actions
        //cameraAnimator.Play("camera1");
        CameraAnimation("camera1");
        

        switch (parachuteDetector.isParachuteOpen)
        {
            case false:
                Animation("OpenParachute");
                animator.speed = 2;
                break;
            case true:
                Animation("ParachuteIdle");
                animator.speed = 1;
                objectParachute.enabled = true;
                objectParachute.transform.localScale = Vector3.Lerp(objectParachute.transform.localScale, new Vector3(40, 72, 60), 0.1f);
                if (!isParachuteOn)
                {
                    parachuteAudio.Play();
                    isParachuteOn = true;
                }
                break;
        }
        
        //rb.MoveRotation(Quaternion.Euler(0, 180, 0));
        //this.transform.rotation = Quaternion.Slerp(Quaternion.Euler(90,180,this.transform.rotation.z),Quaternion.Euler(0,180,this.transform.rotation.z), 1 * Time.fixedDeltaTime);

        /*switch (isParachuteOn)
        {
            case false: 
                Animation("OpenParachute");
                
                if (!parachuteOpen)
                {
                    //rb.MoveRotation(Quaternion.Euler(0, this.transform.rotation.z, 0));
                    //transform.rotation = Quaternion.Euler(0f, this.transform.rotation.z, 0f);
                    //AudioSource.PlayClipAtPoint(parachuteAudio, this.transform.position, 1);
                }
                //this.transform.rotation = Quaternion.Slerp();
                        break;
            case true: Animation("ParachuteIdle"); break;
        }*/
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

    private void Start()
    {
        objectParachute = this.transform.GetChild(1).GetComponent<MeshRenderer>();
        objectParachute.enabled = false;

        rb = this.GetComponent<Rigidbody>();
    }

    public void IsParachuteOn(int on)
    {
        if (on == 1)
        {
            isParachuteOn = true;
        }
    }

    public void OpenParachute(int on)
    {
        if (on == 1)
        {
            parachuteOpen = true;
        }
    }

    void Animation(string state)
    {
        if (!animator.GetNextAnimatorStateInfo(0).IsName(state) && !animator.GetCurrentAnimatorStateInfo(0).IsName(state))
        {
            animator.CrossFadeInFixedTime(state, transitionTime * Time.fixedDeltaTime, -1, 0, 0);
        }
        //animator.speed = Mathf.Abs(rb.velocity.y) * animationSpeed * Time.fixedDeltaTime;
        animator.speed = animationSpeed;
    }

    void CameraAnimation(string state)
    {
        if (!cameraAnimator.GetNextAnimatorStateInfo(0).IsName(state) && !cameraAnimator.GetCurrentAnimatorStateInfo(0).IsName(state))
        {
            cameraAnimator.CrossFadeInFixedTime(state, transitionTime * Time.fixedDeltaTime, -1, 0, 0);
        }
    }
}
