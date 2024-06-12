using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICompass : MonoBehaviour
{
    GameObject player;
    GameObject target;

    private void Start()
    {
        player = GameObject.Find("Player");
        target = GameObject.Find("Target");
    }
    void Update()
    {
        var directionVector = (player.transform.position - target.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(player.transform.up, directionVector);
        transform.rotation = Quaternion.Euler(0,0, lookRotation.eulerAngles.y + 180);
    }
}
