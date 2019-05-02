using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zlew : MonoBehaviour {

    public GameObject gondola;
    public GameObject mouseFollow;
    public GameObject Global;
    public GameObject Quest;
    public GameObject sceneManager;
    public GameObject eq;
    public float distance;

    private bool action = false;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (action && Global.GetComponent<Global>().getGonbool("umytezeby") == false)
        {
            if (mouseFollow.GetComponent<Mouse>().attachedID != 2)
            {
                Quest.GetComponent<Quest>().newQuest("Znajdź szczoteczkę");
            }
            if (mouseFollow.GetComponent<Mouse>().attachedID == 2)
            {
                eq.GetComponent<EQ>().delItem(2);
                sceneManager.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Zęby");
            }
            action = false;
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
