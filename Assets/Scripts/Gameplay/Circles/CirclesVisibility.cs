using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclesVisibility : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player1");
    }

    void Update()
    {
        foreach (Transform child in this.transform)
        {
            if ((player.transform.position.y < child.position.y + 200 && player.transform.position.y > child.position.y - 200))
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
