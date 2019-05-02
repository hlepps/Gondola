using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Name : MonoBehaviour {

    public string setName;
    public string thisname;
    public bool disabled;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!disabled)
        {
            thisname = setName;
        }
        else thisname = "";
	}
}
