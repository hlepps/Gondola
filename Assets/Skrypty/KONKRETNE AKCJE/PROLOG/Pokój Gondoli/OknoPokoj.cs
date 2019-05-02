using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OknoPokoj : MonoBehaviour {

    public GameObject sprite;
    public GameObject kamien;
    public GameObject gondola;
    public GameObject Global;
    public float distance;
    public AudioClip ac;
    public GameObject global;
    public GameObject sceneManager;

    private bool action;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (action)
        {
            Debug.Log("Okno " + Global.GetComponent<Global>().getGonbool("odKam"));
            if (Global.GetComponent<Global>().getGonbool("oknozbite"))
            {
                gondola.GetComponent<Gondola>().say("Coś pękło", 2, 0, ac);

                if (gondola.GetComponent<Gondola>().ResetAction(1))
                {
                    action = false;
                }
            }
            if (Global.GetComponent<Global>().getGonbool("odKam"))
            {
                gondola.GetComponent<Gondola>().say("Ho ho ho", 2, 0, ac);
                if (gondola.GetComponent<Gondola>().ResetAction(1))
                {
                    action = false;
                    sceneManager.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Przedblocze");
                }

            }
            else action = false;



        }
    }

    public void doAction()
    {
        
            sprite.SetActive(true);
            GetComponent<AudioSource>().Play();
            
        
    }
        

    

    public void openKamien()
    {
        kamien.SetActive(true);
        kamien.GetComponent<Name>().disabled = false;
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            action = true;
        }
    }
}
