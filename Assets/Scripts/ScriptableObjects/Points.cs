using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Points", menuName = "ScriptableObjects/Points", order = 1)]
public class Points : ScriptableObject  
{
    public int points;
    public List<int> pointList;
}
