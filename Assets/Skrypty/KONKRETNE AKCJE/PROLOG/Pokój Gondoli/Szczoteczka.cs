using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Szczoteczka : MonoBehaviour {

    public GameObject gondola;
    public GameObject EQ;
    public GameObject UI_Element;
    public GameObject Global;
    public string textToSay;
    public float distance;
    public AudioClip ac;

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
            if (Global.GetComponent<Global>().getGonbool("poducha") == true)
            {
                gondola.GetComponent<Gondola>().say(textToSay, 3, 0, ac);
                
                if (gondola.GetComponent<Gondola>().ResetAction(1))
                {
                    action = false;
                    taken = true;
                    EQ.GetComponent<EQ>().addItem(this.gameObject);
                    GetComponent<SetZ>().multiplier = -1000;
                    Global.GetComponent<Global>().setGonbool("szczoteczka", true);
                }
                
            }
        }

        
    }

    private void OnMouseDown()
    {

        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            if (Global.GetComponent<Global>().getGonbool("poducha") == true)
            {
                action = true;
            }
        }
    }
}