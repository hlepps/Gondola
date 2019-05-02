using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlikNaKota : MonoBehaviour {

    public bool click;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


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
