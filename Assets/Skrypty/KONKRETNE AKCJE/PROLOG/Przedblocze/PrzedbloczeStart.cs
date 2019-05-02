using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzedbloczeStart : MonoBehaviour {

    public GameObject datboi;
    public GameObject gondola;
    public GameObject kabel;

    public AnimationClip startAnim;
    public AudioClip urwiesz, urwales;
    public GameObject there;

    public GameObject datboipath;

    bool action;

    int currAction;

    // Use this for initialization
    void Start () {
        action = true;
	}

    bool tp;

	// Update is called once per frame
	void Update () {
        if (action)
        {
            gondola.GetComponent<Gondola>().playAnim(startAnim, 0);
            PlayMusic(urwiesz, 50000, 0);
            if (currAction == 1 && !tp)
            {
                kabel.GetComponent<Kabel>().zerwij();
                tp = true;
            }
            PlayMusic(urwales, 50000, 1);
            

            datboi.GetComponent<AudioSource>().panStereo -= Time.deltaTime/8;
            if(datboi.GetComponent<AudioSource>().panStereo <= 0)
            {
                datboi.GetComponent<AudioSource>().volume-=Time.deltaTime/4;
                if(datboi.GetComponent<AudioSource>().volume <= 0)
                {
                    gondola.GetComponent<Gondola>().stopAnim(0);
                    Destroy(datboi);
                    if (gondola.GetComponent<Gondola>().ResetAction(1))
                    {
                        Destroy(this.gameObject);
                    }
                    action = false;
                }
            }


        }
	}

    bool played = false;
    void PlayMusic(AudioClip mus, ulong offset, int action)
    {
        if(action == currAction)
        {
            
            
            
            if (GetComponent<AudioSource>().isPlaying == false && played == false)
            {
                played = true;
                GetComponent<AudioSource>().clip = mus;
                GetComponent<AudioSource>().Play(offset);
                
            }
            if (GetComponent<AudioSource>().isPlaying == false && played)
            {
                played = false;
                currAction++;
            }

        }
    }
}
