using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] InputActionAsset input;
    [SerializeField] GameObject pauseCanvas;

    private void Start()
    {
        //pauseCanvas = GameObject.Find("CanvasPause");
    }

    // Update is called once per frame
    void Update()
    {
        var pause = input.FindActionMap("Player").FindAction("pause").ReadValue<float>();

        if (pause == 1)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
