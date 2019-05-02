using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanar : MonoBehaviour {

    bool saying, done;
    string toSay;
    float timeToSay;
    public GameObject text;
    float timeTemp;
    int ca;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(saying)
        {
            if (saying)
            {
                text.GetComponent<TMPro.TextMeshPro>().text = toSay;
                timeTemp += Time.deltaTime;
                if (timeTemp >= timeToSay)
                {
                    ca++;
                    text.GetComponent<TMPro.TextMeshPro>().text = " ";
                    timeTemp = 0;
                    done = true;
                    saying = false;
                    
                }

            }
        }


	}

    public void say(string text, float time, int number, AudioClip audioclip)
    {

        if (saying == false && number == ca)
        {
            GetComponent<AudioSource>().clip = audioclip;
            GetComponent<AudioSource>().Play();
            toSay = text;
            timeToSay = time;
            saying = true;

        }
    }

    public bool ResetAction(int numberToReset)
    {
        if (ca == numberToReset)
        {
            ca = 0;
            return true;
        }
        else return false;
    }
}
