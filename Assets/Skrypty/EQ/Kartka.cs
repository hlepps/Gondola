using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kartka : MonoBehaviour {

    public GameObject text, btext;
    public GameObject kartka, bkartka, custom;
    //public string setText;


    bool x;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(x)
        {
            if(Input.GetMouseButtonDown(1))
            {
                //Debug.Log("Closing Kartka");
                kartka.GetComponent<SpriteRenderer>().enabled = false;
                bkartka.GetComponent<SpriteRenderer>().enabled = false;
                custom.GetComponent<SpriteRenderer>().enabled = false;
                text.GetComponent<TMPro.TextMeshPro>().text = "";
                btext.GetComponent<TMPro.TextMeshPro>().text = "";
                x = false;
            }
        }
    }

    public void showKartka(string s)
    {
        //Debug.Log("Showing Kartka");
        text.GetComponent<TMPro.TextMeshPro>().text = s;
        kartka.GetComponent<SpriteRenderer>().enabled = true;// SetActive(true);
        x = true;
    }

    public void showCustomKartka(string s, Sprite sp)
    {
        //Debug.Log("Showing Kartka");
        text.GetComponent<TMPro.TextMeshPro>().text = s;
        custom.GetComponent<SpriteRenderer>().sprite = sp;
        custom.GetComponent<SpriteRenderer>().enabled = true;// SetActive(true);
        x = true;
    }

    public void showBigKartka(string s)
    {
        bkartka.GetComponent<SpriteRenderer>().enabled = true;
        btext.GetComponent<TMPro.TextMeshPro>().text = s;
        x = true;
    }
}
