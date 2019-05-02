using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patyk : MonoBehaviour {

    public GameObject gondola;
    public float distance;
    public GameObject goTo;

    private bool action;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (action)
        {
            gondola.GetComponent<Gondola>().say("Ale ladny patycek", 5, 0);
            gondola.GetComponent<Gondola>().say("Chcialbym moc go podniesc", 5, 1);
            gondola.GetComponent<Gondola>().destination(goTo.transform.position, 2);
            if (gondola.GetComponent<Gondola>().ResetAction(3))
            {
                action = false;
            }
        }
        
    }

    private void OnMouseDown()
    {
        
        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            action = true;
        }
    }
}
