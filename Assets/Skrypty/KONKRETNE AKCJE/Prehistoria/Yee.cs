using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yee : MonoBehaviour {

    public GameObject mouseFollow, bigYee, eq, koloNaScenie;
    bool action;
    bool once;
	
	void Start () {
		
	}
	
	
	void Update () {
		if(action)
        {
            if(mouseFollow.GetComponent<Mouse>().attachedID != 9)
            {
                GetComponent<AudioSource>().Play();
                bigYee.GetComponent<AudioSource>().Play();
                action = false;
            }
            else
            {
                if (!once)
                {
                    GameJolt.API.Trophies.Unlock(105179, (bool success) => {
                        if (success)
                        {
                            Debug.Log("Success!");
                        }
                        else
                        {
                            Debug.Log("Something went wrong");
                        }
                    });
                    GetComponent<AudioSource>().Play();
                    eq.GetComponent<EQ>().addItem(10);
                    eq.GetComponent<EQ>().delItem(9);
                    mouseFollow.GetComponent<Mouse>().attached = null;
                    Destroy(koloNaScenie);
                    action = false;
                    once = true;
                }
            }
        }
	}

    private void OnMouseDown()
    {

        action = true;

    }
}
