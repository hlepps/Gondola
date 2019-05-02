using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour {

    public GameObject Quest;
    public GameObject Global;
    public GameObject Okno;
    public GameObject Gondola;
    public AnimationClip anim;


	// Use this for initialization
	void Start () {

        //Global.GetComponent<Global>().setGonbool("umytezeby", false);
        //Global.GetComponent<Global>().setGonbool("umyjzeby", true);

        

        

        if(Global.GetComponent<Global>().getGonbool("oknozbite"))
        {
            if (Global.GetComponent<Global>().getGonbool("oknoJUZzbite") == false)
            {
                //Global.GetComponent<Global>().setGonbool("umytezeby", false);
                Okno.GetComponent<OknoPokoj>().doAction();
                Quest.GetComponent<Quest>().newQuest("Sprawdź co się dzieje");
                Global.GetComponent<Global>().setGonbool("oknoJUZzbite", true);
            }

        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!Global.GetComponent<Global>().getGonbool("animacjaStartGry"))
        {
            ///*
            Gondola.GetComponent<Gondola>().playAnim(anim, 0);
            if (Gondola.GetComponent<Gondola>().ResetAction(1))
            {
                Global.GetComponent<Global>().setGonbool("animacjaStartGry", true);
            };
            //*/
        }

        if (!Global.GetComponent<Global>().getGonbool("umyjzeby") && Global.GetComponent<Global>().getGonbool("animacjaStartGry"))
        {
            Global.GetComponent<Global>().setGonbool("umyjzeby", true);
            Quest.GetComponent<Quest>().newQuest("Umyj zęby");

        }
    }
}
