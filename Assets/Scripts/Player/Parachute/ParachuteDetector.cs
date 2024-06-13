using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParachuteDetector : MonoBehaviour
{
    public bool isParachuteOpen;

    public void ParachuteOpen(int value)
    {
        if (value == 1)
        {
            isParachuteOpen = true;
        }
    }
}
