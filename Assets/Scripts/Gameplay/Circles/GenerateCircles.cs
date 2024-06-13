using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject circle;

    void Start()
    {
        player = GameObject.Find("Player1");
        float playerHeight = player.transform.position.y; // Find player initial height;

        for (int i = 1; i < ((playerHeight - 100) * 0.01f); i++) // Instantiate circles. Quantity depends on player initial height.
        {
            Instantiate(circle, new Vector3(0, -1 , 0), Quaternion.identity, this.transform);
        }

        foreach(Transform child in this.transform) //Change position of each circle.
        {
            child.position = new Vector3(0,((child.transform.GetSiblingIndex() + 1) * 100) + 100, 0);
        }
    }
}
