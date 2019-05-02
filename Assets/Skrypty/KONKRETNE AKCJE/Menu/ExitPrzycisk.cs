using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPrzycisk : MonoBehaviour {

    public Sprite normal;
    public Sprite clicked;
    public GameObject sceneManager;
    public GameObject btaudio;
    public GameObject clickAudio;

    public Color normalColor;
    public Color najechanedColor;


   

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
            
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = clicked;
            Application.Quit();
        }
        clickAudio.GetComponent<AudioSource>().Play();
    }
}