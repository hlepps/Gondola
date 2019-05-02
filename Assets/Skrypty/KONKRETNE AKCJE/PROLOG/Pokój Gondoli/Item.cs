using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public GameObject gondola;
    public GameObject EQ;
    public GameObject UI_Element;
    public GameObject Global;
    public AudioClip ac;


    public GameObject szczoteczka;

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
        if(Global.GetComponent<Global>().getGonbool("oknozbite"))
        {
            taken = false;
            Global.GetComponent<Global>().setGonbool("poducha", false);
            EQ.GetComponent<EQ>().delItem(this.gameObject);
        }
        if (action && !Global.GetComponent<Global>().getGonbool("oknozbite"))
        {
            Debug.Log("action!");
            gondola.GetComponent<Gondola>().say(textToSay, 3, 0, ac);
            Global.GetComponent<Global>().setGonbool("poducha", true);
            szczoteczka.GetComponent<Name>().disabled = false;
            
            if (gondola.GetComponent<Gondola>().ResetAction(1))
            {
                action = false;
                taken = true;
                EQ.GetComponent<EQ>().addItem(this.gameObject);
                GetComponent<SetZ>().multiplier = -1000;
            }
            
        }

        if (taken)
        {
            this.gameObject.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down on poducha");
        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            action = true;
        }
    }
    

}