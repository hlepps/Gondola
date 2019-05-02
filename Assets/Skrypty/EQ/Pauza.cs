using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauza : MonoBehaviour {

    public GameObject Global;
    public GameObject all;

	// Use this for initialization
	void Start () {
        all.SetActive(false);
        Global.GetComponent<Global>().paused = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Global.GetComponent<Global>().paused)
            {
                Global.GetComponent<Global>().paused = false;
                
            }
            else if (!Global.GetComponent<Global>().paused)
            {
                Global.GetComponent<Global>().paused = true;
            }
        }


        if( Global.GetComponent<Global>().paused )
        {
            all.SetActive(true);
        }
        else
        {
            all.SetActive(false);
        }


    }
}
