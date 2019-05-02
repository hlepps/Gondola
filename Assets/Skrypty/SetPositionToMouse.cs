using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionToMouse : MonoBehaviour {

    public GameObject camera;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate() {
        
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Vector3 worldPos = camera.GetComponent<Camera>().ScreenToWorldPoint(mousePos);
        //Debug.Log(worldPos.x + "; " + worldPos.y + "; " + worldPos.y);
        transform.Translate(worldPos.x - transform.position.x, worldPos.y - transform.position.y, worldPos.y - transform.position.z);
        
            
	}

    
}
