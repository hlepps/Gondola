using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obraz : MonoBehaviour {

    public GameObject gondola;
    public GameObject mouseFollow;
    public float distance;
    public AudioClip dzban;
    public AudioClip fajne;
    public AudioClip czyste;
    public AudioClip zly;

    private bool action;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (action)
        {
            if(mouseFollow.GetComponent<Mouse>().attachedID == 0)
                gondola.GetComponent<Gondola>().say("He he ale dzban", 3, 0, dzban);
            if(mouseFollow.GetComponent<Mouse>().attachedID == 1)
                gondola.GetComponent<Gondola>().say("Szkoda zdjęcia fajne jest", 3, 0, fajne);
            if (mouseFollow.GetComponent<Mouse>().attachedID == 2)
                gondola.GetComponent<Gondola>().say("Nie no czyste jest hehe", 3, 0, czyste);
            if (mouseFollow.GetComponent<Mouse>().attachedID > 2)
                gondola.GetComponent<Gondola>().say("Zły pomysł", 3, 0, zly);
            if (gondola.GetComponent<Gondola>().ResetAction(1))
            {
                action = false;
            }
        }
    }

    private void OnMouseDown()
    {

        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            action = true;
        }
    }
}
