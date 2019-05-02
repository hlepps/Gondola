using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPrzycisk : MonoBehaviour {

    public Sprite normal;
    public Sprite clicked;
    public GameObject sceneManager;
    public GameObject btaudio;
    public GameObject clickAudio;
    public GameObject AudioPanel;
    public GameObject GrafikaPanel;
    public GameObject grafikaPrzycisk;


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

    public AudioMixer mixer;

    private void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().sprite == clicked)
        {
            AudioPanel.SetActive(false);
            GetComponent<SpriteRenderer>().sprite = normal;

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = clicked;
            grafikaPrzycisk.GetComponent<SpriteRenderer>().sprite = grafikaPrzycisk.GetComponent<GrafikaPrzycisk>().normal;
            AudioPanel.SetActive(true);
            GrafikaPanel.SetActive(false);

            

            


            
        }
        clickAudio.GetComponent<AudioSource>().Play();
    }
}
