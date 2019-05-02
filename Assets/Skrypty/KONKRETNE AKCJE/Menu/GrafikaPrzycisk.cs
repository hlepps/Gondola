using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrafikaPrzycisk : MonoBehaviour {

    public Sprite normal;
    public Sprite clicked;
    public GameObject sceneManager;
    public GameObject btaudio;
    public GameObject clickAudio;
    public GameObject AudioPanel;
    public GameObject GrafikaPanel;
    public GameObject audioPrzycisk;

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
            GrafikaPanel.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = normal;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = clicked;
            audioPrzycisk.GetComponent<SpriteRenderer>().sprite = audioPrzycisk.GetComponent<AudioPrzycisk>().normal;
            GrafikaPanel.SetActive(true);
            AudioPanel.SetActive(false);
        }
        clickAudio.GetComponent<AudioSource>().Play();
    }
}
