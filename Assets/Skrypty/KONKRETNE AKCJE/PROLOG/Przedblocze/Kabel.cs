using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kabel : MonoBehaviour {

    public Sprite zerwany;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    

    public void zerwij()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = zerwany;
    }
}
