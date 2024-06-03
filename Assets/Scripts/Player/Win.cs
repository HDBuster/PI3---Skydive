using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    Rigidbody rb;
    PlayerMachineStates.State state;

    public bool playerWin = false;
    public bool playerDefeat = false;

    [SerializeField] PostGameSFX gameSFX;

    /*[SerializeField] AudioClip landGround;
    [SerializeField] AudioClip seaWater;
    [SerializeField] AudioClip parachuteWater;*/

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        state = GetComponent<PlayerMachineStates>().state;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinFinish") && state == PlayerMachineStates.State.Parachute)
        {
            playerWin = true;
            WinScene();
            gameSFX.sound = 1;
        }
        else if (collision.gameObject.CompareTag("Ground") && state == PlayerMachineStates.State.Parachute)
        {
            playerDefeat = true;
            LoseScene();
            gameSFX.sound = 2;
        }
        else if (collision.gameObject.CompareTag("WinFinish") && state != PlayerMachineStates.State.Parachute)
        {
            playerDefeat = false;
            //AudioSource.PlayClipAtPoint(landGround, this.transform.position, 1);
            LoseScene();
            gameSFX.sound = 2;
        }
        else if (collision.gameObject.CompareTag("Ground") && state != PlayerMachineStates.State.Parachute)
        {
            playerDefeat = true;
            //AudioSource.PlayClipAtPoint(landGround, this.transform.position, 1);
            LoseScene();
            gameSFX.sound = 2;
        }
        else if (collision.gameObject.CompareTag("SeaWater"))
        {
            playerDefeat = true;
            //AudioSource.PlayClipAtPoint(parachuteWater, this.transform.position, 1);
            LoseScene();
            gameSFX.sound = 3;
        }
    }

    private void WinScene()
    {
        SceneManager.LoadSceneAsync(2);
    }

    private void LoseScene()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
