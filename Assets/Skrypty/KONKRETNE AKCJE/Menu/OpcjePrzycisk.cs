using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcjePrzycisk : MonoBehaviour {

    public Sprite normal;
    public Sprite clicked;
    public GameObject sceneManager;
    public GameObject btaudio;
    public GameObject clickAudio;
    public GameObject Opcje, zapisz, wczytaj;

    public Color normalColor;
    public Color najechanedColor;

    private float temp;

    private void Start()
    {
        Opcje.GetComponent<OpcjeController>().audiopanel.SetActive(true);
        Opcje.GetComponent<OpcjeController>().grafikapanel.SetActive(true);
        temp = 0.1f;
        
    }
    private void Update()
    {
        
        if (temp <= 0 && temp > -50)
        {
            Opcje.GetComponent<OpcjeController>().audiopanel.SetActive(false);
            Opcje.GetComponent<OpcjeController>().grafikapanel.SetActive(false);
            temp = -100;
        }
        else temp--;
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
            Opcje.GetComponent<OpcjeController>().disable();
            zapisz.SetActive(true);
            wczytaj.SetActive(true);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = clicked;
            Opcje.SetActive(true);
            zapisz.SetActive(false);
            wczytaj.SetActive(false);
        }
        clickAudio.GetComponent<AudioSource>().Play();
    }
}
