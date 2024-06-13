using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCircles : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [Header("Circles")]
    [SerializeField] GameObject redCircle;
    [SerializeField] GameObject greenCircle;
    [SerializeField] GameObject blueCircle;
    [SerializeField] GameObject yellowCircle;

    [Header("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject target;

    void Start()
    {
        //player = GameObject.Find("Player1");
        float playerHeight = player.transform.position.y; // Find player initial height;

        var directionVector = (player.transform.position - target.transform.position).normalized;

        /*for (int i = 1; i < ((playerHeight - 100) * 0.01f); i++) // Instantiate circles. Quantity depends on player initial height.
        {
            Instantiate(circle, new Vector3(0, -1 , 0), Quaternion.identity, this.transform);
        }*/

        /*for (int i = 1; i < ((playerHeight - 200) * 0.005f); i++) // Instantiate circles. Quantity depends on player initial height.
        {
            Instantiate(circle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
        }*/

        for (int i = 1; i < ((playerHeight - 200) * 0.005f); i++) // Instantiate circles. Quantity depends on player initial height.
        {
            var random = Random.Range(0, 4);
            switch (random)
            {
                case 0:
                    Instantiate(redCircle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
                    break;
                case 1:
                    Instantiate(greenCircle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
                    break;
                case 2:
                    Instantiate(blueCircle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
                    break;
                case 3:
                    Instantiate(yellowCircle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
                    break;

            }
            //Instantiate(circle, new Vector3(0, -1, 0), Quaternion.identity, this.transform);
        }

        foreach (Transform child in this.transform) //Change position of each circle.
        {
            //child.position = new Vector3(0,((child.transform.GetSiblingIndex() + 1) * 100) + 100, 0); //Initial
            child.position = new Vector3((((directionVector.x * child.transform.GetSiblingIndex()) + 1) * 200) + Random.Range(-100,100),
                                        ((child.transform.GetSiblingIndex() + 1) * 200) + 200,
                                        (((directionVector.z * child.transform.GetSiblingIndex()) + 1) * 200) + Random.Range(-100,100));
            /*child.position = new Vector3(child.position.x * directionVector.x
                                        ,child.position.y * directionVector.y
                                        ,child.position.z * directionVector.z);*/
        }
    }
}
