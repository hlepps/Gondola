using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPrehistoria : MonoBehaviour {

    public GameObject quest, kermit, gondola;
    public AudioClip czesc;

    bool action;
	void Start () {
        action = true;
        quest.GetComponent<Quest>().newQuest("Uratuj ziomków");
        gondola = GameObject.FindGameObjectWithTag("Gondola");
	}
	
	
	void Update () {
        if (action)
        {
            gondola.GetComponent<Gondola>().say("", 9.0f, 0);
            kermit.GetComponent<Kot>().say(" ", 1.0f, 0);
            kermit.GetComponent<Kot>().say("O, cześć Gondola", 2.5f, 1, czesc);
            kermit.GetComponent<Kot>().say("Nie przejmuj się mną, idź znajź kota", 4.0f, 2);
            kermit.GetComponent<Kot>().say("Ja see tu poleżę", 2.5f, 3);
            if(kermit.GetComponent<Kot>().ResetAction(4) && gondola.GetComponent<Gondola>().ResetAction(1))
            {
                quest.GetComponent<Quest>().newQuest("Znajdź kota");
                action = false;
            }
        }

    }
}
