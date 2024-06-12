using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAltitudeUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI altitudeUI;

    // Update is called once per frame
    void Update()
    {
        altitudeUI.text = Mathf.CeilToInt(this.transform.position.y).ToString() + "m";
    }
}
