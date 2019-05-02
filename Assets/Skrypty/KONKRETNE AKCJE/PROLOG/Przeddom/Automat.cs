using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automat : MonoBehaviour {

    public GameObject mouse, eq;
    bool click;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (click && mouse.GetComponent<Mouse>().attachedID == 4)
        {
            GetComponent<AudioSource>().Play();
            eq.GetComponent<EQ>().addItem(7);
            eq.GetComponent<EQ>().delItem(4);
            click = false;
        }
        else if (click && mouse.GetComponent<Mouse>().attachedID != 4)
        {
            GetComponent<AudioSource>().Play();
            click = false;
        }
    }

    private void OnMouseDown()
    {
        click = true;
    }
}
