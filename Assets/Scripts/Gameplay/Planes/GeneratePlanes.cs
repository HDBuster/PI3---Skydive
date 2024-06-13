using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GeneratePlanes : MonoBehaviour
{
    [Header("Planes")]
    [SerializeField] GameObject planeBlack;
    [SerializeField] GameObject planeBlackGreen;
    [SerializeField] GameObject planeBlue;
    [SerializeField] GameObject planeGreen;

    [Header("References")]
    [SerializeField] GameObject player;

    //float randomSpawnArea;
    [Header("List of Heights")]
    [SerializeField]List<float> planeHeights = new List<float>();
    int heightIndex;

    // Start is called before the first frame update
    void Start()
    {
        /*randomSpawnArea = Random.Range  (player.transform.position.y * (1 / 3),
                                         player.transform.position.y * (2 / 3));*/

        heightIndex = 0;

        var playerHeight = player.transform.position.y;

        var randomQuantity = Random.Range(3, 5);

        for (int i = 1; i < randomQuantity; i++)
        {
            var randomSpawnArea = Random.Range(4000, 8000);

            if (i == 1)
            {
                planeHeights.Add(randomSpawnArea);
            }
            else if (i > 1)
            {
                planeHeights.Add(randomSpawnArea);
            }
        }

        for (int i = 1; i < randomQuantity; i++)
        {
            var randomPlane = Random.Range(0, 4);
            switch (randomPlane)
            {
                case 0:
                    Instantiate(planeBlack, new Vector3(0, -10, 0), Quaternion.identity, this.transform);
                    break;
                case 1:
                    Instantiate(planeBlackGreen, new Vector3(0, -10, 0), Quaternion.identity, this.transform);
                    break;
                case 2:
                    Instantiate(planeBlue, new Vector3(0, -10, 0), Quaternion.identity, this.transform);
                    break;
                case 3:
                    Instantiate(planeGreen, new Vector3(0, -10, 0), Quaternion.identity, this.transform);
                    break;
            }
        }

        foreach (Transform child in this.transform)
        {
            foreach (Transform pieces in child.transform)
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
                //pieces.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }

        planeHeights = planeHeights.Distinct().OrderByDescending(x => x).ToList();
    }

    private void FixedUpdate()
    {
        if (player.transform.position.y <= planeHeights[heightIndex] + 10 && player.transform.position.y >= planeHeights[heightIndex])
        {
            var randomRotation = Random.Range(0,360);
            transform.GetChild(heightIndex).gameObject.GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(heightIndex).transform.position = new Vector3(player.transform.position.x - 1200, player.transform.position.y - 1200, player.transform.position.z - 1200);
            transform.GetChild(heightIndex).transform.rotation = Quaternion.Euler(0,randomRotation,0);
            heightIndex++;
        }
    }
}
