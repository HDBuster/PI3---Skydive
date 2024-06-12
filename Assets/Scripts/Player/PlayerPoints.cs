using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [SerializeField] Points points;
    [SerializeField] AudioClip pointClip;
    [SerializeField] AudioMixerGroup mixerGroup;

    [SerializeField] TextMeshProUGUI pointUI;
    Rigidbody rb;

    private void Start()
    {
        points.points = 0;
        rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        pointUI.text = points.points.ToString() + " p";
    }

    private void OnTriggerEnter(Collider col)
    {        
        if (col.gameObject.CompareTag("PointCircle"))
        {
            col.gameObject.SetActive(false);
            points.points++;
            AudioSource.PlayClipAtPoint(pointClip, this.transform.position, 1);
        }
    }
}
