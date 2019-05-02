using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazienkaSceneStart : MonoBehaviour {

    public GameObject Global;
    public GameObject Quest;
	// Use this for initialization
	void Start () {
        if (Global.GetComponent<Global>().getGonbool("umytezeby") && !Global.GetComponent<Global>().getGonbool("oknozbite"))
        {
            Quest.GetComponent<Quest>().newQuest("Połóż się spać");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
