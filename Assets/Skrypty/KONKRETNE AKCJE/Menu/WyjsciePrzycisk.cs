using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyjsciePrzycisk : MonoBehaviour {

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
        clickAudio.GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = clicked;
        sceneManager.GetComponent<SceneManager>().ExitGame();
    }
}
