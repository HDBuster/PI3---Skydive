using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicSlider : MonoBehaviour
{
    [SerializeField]
    AudioMixer mixer;
    [SerializeField]
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void OnChangeSlider(float value)
    {
        mixer.SetFloat("Music", Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat("Music", value);
        PlayerPrefs.Save();
    }
}
