using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parowa : MonoBehaviour {

    public GameObject gondola;
    public GameObject EQ;
    public GameObject UI_Element;
    public GameObject Global;



    public string textToSay;
    public float distance;

    private static bool taken;
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
            gondola.GetComponent<Gondola>().say(textToSay, 3, 0);
            
            if (gondola.GetComponent<Gondola>().ResetAction(1))
            {
                action = false;
                taken = true;
                EQ.GetComponent<EQ>().addItem(this.gameObject);
                GetComponent<SetZ>().multiplier = -1000;
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