using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lozko : MonoBehaviour {

    public GameObject Global;
    public GameObject gondola;
    public GameObject Quest;
    public GameObject gondolaPrzyDrzwiach;
    public GameObject SceneManager;
    public GameObject mouseFollow;
    public GameObject eq;
    public float distance;

    private bool action;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(action)
        {
            if (Global.GetComponent<Global>().getGonbool("umytezeby") && mouseFollow.GetComponent<Mouse>().attachedID == 1)
            {
                Debug.Log("umyte");
                gondola.GetComponent<Gondola>().say("Uaaa", 1, 0);

                //if (gondola.GetComponent<Gondola>().ResetAction(1))
                //{
                    gondolaPrzyDrzwiach.GetComponent<Pokoj_Lazienka>().setStatic(false);
                    Global.GetComponent<Global>().setGonbool("oknozbite", true);
                    eq.GetComponent<EQ>().delItem(1);
                    SceneManager.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Pokoj Gondoli");
                    
                    action = false;

                //}
            }
            else action = false;
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
