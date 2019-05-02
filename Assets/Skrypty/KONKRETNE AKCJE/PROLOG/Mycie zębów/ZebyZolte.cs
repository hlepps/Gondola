using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebyZolte : MonoBehaviour {

    public float alpha;
    public float minus;

    public GameObject audio;
    public GameObject piana;
    public GameObject victory;
    public GameObject sceneManager;
    public GameObject Global;

    private bool ok;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Color c = GetComponent<SpriteRenderer>().color;
        c.a = alpha;
        GetComponent<SpriteRenderer>().color = c;

        if(ok)
        {
            audio.GetComponent<AudioSource>().mute = false;
            piana.SetActive(true);
            alpha -= minus;
        }
        else if (!ok)
        {
            audio.GetComponent<AudioSource>().mute = true;
            piana.SetActive(false);
        }


        if(alpha <= 0)
        {
            victory.GetComponent<AudioSource>().Play();
            Global.GetComponent<Global>().setGonbool("umytezeby", true);
            sceneManager.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Łazienka");
        }


	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        ok = true;
        Debug.Log("collision w/ " + other.name);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ok = false;   
    }

}
