using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetZ : MonoBehaviour {

    public GameObject pivot;

    public int multiplier = -100;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<SpriteRenderer>().sortingOrder = (int)(pivot.transform.position.y * multiplier);
    }
}
