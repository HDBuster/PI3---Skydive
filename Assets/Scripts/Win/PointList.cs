using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PointList : MonoBehaviour
{
    [SerializeField] Points points;

    [SerializeField] TextMeshProUGUI point1;
    [SerializeField] TextMeshProUGUI point2;
    [SerializeField] TextMeshProUGUI point3;
    [SerializeField] TextMeshProUGUI point4;

    void Start()
    {
        points.pointList.Add(points.points);

        switch (points.pointList.Count)
        {
            case 1:
                point1.text = points.pointList.Distinct().OrderByDescending(i => i).First().ToString();
                point1.gameObject.SetActive(true);
                break;
            case 2:
                point1.text = points.pointList.Distinct().OrderByDescending(i => i).First().ToString();
                point1.gameObject.SetActive(true);
                point2.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(1).First().ToString();
                point2.gameObject.SetActive(true);
                break;
            case 3:
                point1.text = points.pointList.Distinct().OrderByDescending(i => i).First().ToString();
                point1.gameObject.SetActive(true);
                point2.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(1).First().ToString();
                point2.gameObject.SetActive(true);
                point3.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(2).First().ToString();
                point3.gameObject.SetActive(true);
                break;
            default:
                point1.text = points.pointList.Distinct().OrderByDescending(i => i).First().ToString();
                point1.gameObject.SetActive(true);
                point2.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(1).First().ToString();
                point2.gameObject.SetActive(true);
                point3.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(2).First().ToString();
                point3.gameObject.SetActive(true);
                point4.text = points.pointList.Distinct().OrderByDescending(i => i).Skip(3).First().ToString();
                point4.gameObject.SetActive(true);
                break;
        }
    }
}
