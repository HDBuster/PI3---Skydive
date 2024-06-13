using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    //[SerializeField] GameObject player;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * 50);
    }
}
