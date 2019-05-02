using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhusPrzeddom : MonoBehaviour {

    public GameObject mouse, drabina, global;

    public Sprite gora, dol;

    public AudioClip dobre, pomaranczowe;

    public bool click, loop;

    public bool spadlo;
	// Use this for initialization
	void Start () {
		
	}
    float time = 6.0f;
	// Update is called once per frame
	void Update () {
		
        if(click && mouse.GetComponent<Mouse>().attachedID == 7 && global.GetComponent<Global>().getGonbool("startPrzeddom"))
        {
            GetComponent<AudioSource>().clip = pomaranczowe;
            GetComponent<AudioSource>().Play();
            click = false;
            Destroy(drabina);
            loop = true;

        }
        else if (click && mouse.GetComponent<Mouse>().attachedID != 7)
        {
            GetComponent<AudioSource>().clip = dobre;
            GetComponent<AudioSource>().Play();
            click = false;
            
        }

        if(loop)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                global.GetComponent<Global>().setGonbool("uratowanoKota", true);
                loop = false;
            }
        }


        if(spadlo)
        {
            GetComponent<SpriteRenderer>().sprite = dol;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = gora;
        }

	}

    private void OnMouseDown()
    {

        click = true;

    }
    private void OnMouseUp()
    {

        click = false;

    }
}
