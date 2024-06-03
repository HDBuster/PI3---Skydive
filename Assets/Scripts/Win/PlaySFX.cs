using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] PostGameSFX gameSFX;

    [SerializeField] AudioClip parachuteGround;
    [SerializeField] AudioClip ground;
    [SerializeField] AudioClip water;
    void Start()
    {
        switch (gameSFX.sound) 
        {
            case 1: AudioSource.PlayClipAtPoint(parachuteGround, this.transform.position, 1); break;
            case 2: AudioSource.PlayClipAtPoint(ground, this.transform.position, 1); break;
            case 3: AudioSource.PlayClipAtPoint(water, this.transform.position, 1); break;
        }
    }
}
