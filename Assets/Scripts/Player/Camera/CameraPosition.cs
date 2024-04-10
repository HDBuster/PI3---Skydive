using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] GameObject player;

    [Header("Shake Settings")]
    [SerializeField] float shakeLimit;
    [SerializeField] float shakeForce;

    [Header("Stats")]
    [SerializeField] float shake;

    Rigidbody prb;

    void Start()
    {
        prb = player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        shake = Mathf.Clamp(Mathf.Abs(prb.velocity.y) * shakeForce, shakeLimit * -1, shakeLimit);

        this.transform.position = player.transform.localPosition 
                                  + new Vector3(0, Random.Range(shake * -1, shake) + 5, 0);

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, 
                                  player.transform.rotation.eulerAngles.y + 90, 
                                  this.transform.rotation.eulerAngles.z);
    }
}
