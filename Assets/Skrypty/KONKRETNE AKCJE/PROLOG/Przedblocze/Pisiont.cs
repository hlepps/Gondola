using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisiont : MonoBehaviour {

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
            //gondola.GetComponent<Gondola>().say(textToSay, 3, 0);

            if (gondola.GetComponent<Gondola>().ResetAction(0))
            {
                action = false;
                taken = true;
                EQ.GetComponent<EQ>().addItem(4);
                Debug.Log("PISIONT");
                GameJolt.API.Trophies.Unlock(103687, (bool success) => {if (success)
                    {
                        Debug.Log("Success!");
                    }
                    else
                    {
                        Debug.Log("Something went wrong");
                    }
                });
    
                //GetComponent<SetZ>().multiplier = -1000;
                
                Destroy(this.gameObject);

            }

        }

        if (taken)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        //if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        //{
            action = true;
        //}
    }
}