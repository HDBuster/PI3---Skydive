using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [SerializeField] Points points;

    private void Start()
    {
        points.points = 0;
    }

    private void OnTriggerEnter(Collider col)
    {        
        if (col.gameObject.CompareTag("PointCircle"))
        {
            col.gameObject.SetActive(false);
            points.points++;
        }
    }
}
