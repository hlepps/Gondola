using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SzczotaMINIGRA : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetMouseButton(0))
        {
            GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("on");
            
}
        if (!Input.GetMouseButton(0))
        {
            GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("off");
            
        }

    }
}
