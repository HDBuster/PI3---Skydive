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
    //[SerializeField] AudioClip pointClip;
    [SerializeField] AudioSource pointClip;
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
        /*if (col.gameObject.CompareTag("PointCircle"))
        {
            col.gameObject.SetActive(false);
            points.points++;
            AudioSource.PlayClipAtPoint(pointClip, this.transform.position, 1);
        }*/
        if (col.gameObject.CompareTag("PointSmall"))
        {
            points.points = points.points + 200;
        }
        if (col.gameObject.CompareTag("PointLarge"))
        {
            points.points = points.points + 50;
            col.transform.parent.gameObject.SetActive(false);
            pointClip.Play();
            pointClip.pitch = Random.Range(1f, 1.5f);
            //AudioSource.PlayClipAtPoint(pointClip, this.transform.position, 1);
        }
    }
}
