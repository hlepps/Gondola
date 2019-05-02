using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakKlamki : MonoBehaviour {

    public GameObject gondola;
    public float distance;

    private bool action;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            gondola.GetComponent<Gondola>().say("He He He", 3, 0);
            if (gondola.GetComponent<Gondola>().ResetAction(1))
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
