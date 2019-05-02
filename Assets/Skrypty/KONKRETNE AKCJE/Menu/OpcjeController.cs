using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpcjeController : MonoBehaviour {

    public GameObject opcjeButton;
    public GameObject audiopanel;
    public GameObject audioprzycisk;
    public GameObject grafikapanel;
    public GameObject grafikaprzycisk;

    public void disable()
    {
        opcjeButton.GetComponent<SpriteRenderer>().sprite = opcjeButton.GetComponent<OpcjePrzycisk>().normal;
        audiopanel.SetActive(false);
        audioprzycisk.GetComponent<SpriteRenderer>().sprite = audioprzycisk.GetComponent<AudioPrzycisk>().normal;
        grafikapanel.SetActive(false);
        grafikaprzycisk.GetComponent<SpriteRenderer>().sprite = grafikaprzycisk.GetComponent<GrafikaPrzycisk>().normal;
        this.gameObject.SetActive(false);

    }
}
