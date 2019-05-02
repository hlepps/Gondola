using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamienZKartka : MonoBehaviour {

    public GameObject kartka, global, quest;


    bool action;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(action)
        {
            kartka.GetComponent<Kartka>().showKartka("Gondola! Pomóż! Wbij na Osiedle Pochmurne na Kaczobrzeżu!");
            global.GetComponent<Global>().setGonbool("oknozbite", false);
            global.GetComponent<Global>().setGonbool("odKam", true);
            quest.GetComponent<Quest>().newQuest("Wyjdz z domu");
            action = false;
        }
	}

    private void OnMouseDown()
    {

        //if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        //{
        action = true;
        //}
    }

}
