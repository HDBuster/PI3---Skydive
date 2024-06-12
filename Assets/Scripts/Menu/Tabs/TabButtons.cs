using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButtons : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject credits;

    private void Start()
    {
        /*menu = GameObject.Find("Menu");
        options = GameObject.Find("Options");
        credits = GameObject.Find("Credits");*/
    }

    public void OptionsButton()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void CreditsButton()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackButton()
    {
        options.SetActive(false);
        credits.SetActive(false);
        menu.SetActive(true);
    }
}
