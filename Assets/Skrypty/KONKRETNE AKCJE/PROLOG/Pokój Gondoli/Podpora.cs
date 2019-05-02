using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podpora : MonoBehaviour {

    //public GameObject sprite;
    //public GameObject kamien;
    public GameObject mouseFollow;
    public GameObject EQ;
    public GameObject Global;
    public GameObject Okno;
    public float distance;

    private bool action;


    // Use this for initialization
    void Start () {
		
	}

    

	// Update is called once per frame
	void Update () {
        if (action && Global.GetComponent<Global>().getGonbool("umytezeby") && Global.GetComponent<Global>().getGonbool("oknozbite"))
        {
            if (mouseFollow.GetComponent<Mouse>().attachedID == 3)
            {
                EQ.GetComponent<EQ>().delItem(3);
                GetComponent<AudioSource>().Play();
                this.gameObject.SetActive(false);
                Okno.GetComponent<OknoPokoj>().openKamien();
                
                //sprite.SetActive(true);
                //kamien.SetActive(true);
                //kamien.GetComponent<Name>().disabled = false;
            }
            
            
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
