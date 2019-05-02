using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenPrzycisk : MonoBehaviour {

    public Sprite normal;
    public Sprite clicked;
    public GameObject sceneManager;
    public GameObject btaudio;
    public GameObject clickAudio;

    public Color normalColor;
    public Color najechanedColor;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = clicked;
    }

    private void OnMouseEnter()
    {
        btaudio.GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().color = najechanedColor;

    }

    private void OnMouseExit()
    {

        GetComponent<SpriteRenderer>().color = normalColor;
    }

    private void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().sprite == clicked)
        {
            Screen.fullScreen = false;
            GetComponent<SpriteRenderer>().sprite = normal;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = clicked;
            Screen.fullScreen = true;
        }
        clickAudio.GetComponent<AudioSource>().Play();
    }
}