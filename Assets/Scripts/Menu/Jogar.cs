using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Jogar : MonoBehaviour
{
    [SerializeField] FirstTime firstTime;
    [SerializeField] GameObject background;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject video;
    [SerializeField] AudioSource menuMusic;
    [SerializeField] VideoPlayer player;
    [SerializeField] InputActionAsset input;
    bool isInVideo;

    // Start is called before the first frame update
    public void PlayGame()
    {
        if (!firstTime.isFirstTime)
        {
            menu.SetActive(false);
            video.SetActive(true);
            menuMusic.Stop();
            background.SetActive(false);
            player.loopPointReached += EndReached;
            firstTime.isFirstTime = true;
            isInVideo = true;
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
        }
        
    }

    private void Update()
    {
        var button = input.FindActionMap("Player").FindAction("parachute").ReadValue<float>();

        if (isInVideo && button == 1)
        {
            player.Stop();
            SceneManager.LoadSceneAsync(1);
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(1);
    }

}
