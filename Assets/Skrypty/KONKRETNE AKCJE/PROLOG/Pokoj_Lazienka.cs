using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokoj_Lazienka : MonoBehaviour {

    public static bool przejscie = false;

    public GameObject gondola;
    public GameObject transform;

	// Use this for initialization
	void Start () {
		if(przejscie)
        {
            gondola.transform.position = transform.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void setStatic(bool x)
    {
        przejscie = x;
    }

}

