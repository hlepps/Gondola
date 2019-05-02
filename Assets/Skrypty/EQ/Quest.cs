using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

    public GameObject mouseFollow;
    public GameObject textObj;
    public GameObject audio;
    public GameObject questAudio;
    public GameObject flara;

    public static string setText;
    public float bounce;
    public float full;
    public float speed;

    private float timer;
    private bool over, show, newquest;

    private Vector3 startPos;
    

    // Use this for initialization
    void Start () {
        startPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        textObj.GetComponent<TMPro.TextMeshPro>().text = setText;

        if (newquest)
        {
            flara.SetActive(true);
        }
        if(!newquest)
        {
            flara.SetActive(false);
        }

        if (over)
        {
            newquest = false;
            

            if (timer >= bounce)
            {
                //timer = 0;
                //over = false;
                if (show)
                {

                    if (timer >= full)
                    {
                    }
                    else
                    {
                        timer += Time.deltaTime * speed;
                        transform.Translate(0, -Time.deltaTime * speed, 0);
                    }
                }
            }
            else
            {
                timer += Time.deltaTime * speed;
                transform.Translate(0, -Time.deltaTime * speed, 0);
            }

        }
        if (!over)
        {
            bool asdf = false;
            if (!asdf)
            {
                show = false;
                if (transform.localPosition.y < startPos.y)
                {
                    transform.Translate(0, Time.deltaTime * speed, 0);
                }
                else
                {
                    transform.localPosition = startPos;
                    timer = 0;
                }
            }
        }
    }


    private void OnMouseEnter()
    {
        
        over = true;
    }

    private void OnMouseExit()
    {
        over = false;
    }

    private void OnMouseDown()
    {
        audio.GetComponent<AudioSource>().Play();
        show = true;
    }

    public void newQuest(string quest)
    {
        if (quest != setText)
        {
            newquest = true;
            setText = quest;
            questAudio.GetComponent<AudioSource>().Play();
        }
    }

}
