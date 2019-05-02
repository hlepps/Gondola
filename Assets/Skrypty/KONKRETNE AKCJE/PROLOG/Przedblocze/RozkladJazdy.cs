using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RozkladJazdy : MonoBehaviour {

    public GameObject kartka, global, quest, tramwaj;

    public Sprite CustomKartka;


    bool action;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            kartka.GetComponent<Kartka>().showCustomKartka("", CustomKartka);
            tramwaj.SetActive(true);
            quest.GetComponent<Quest>().newQuest("Wsiądź do tramwaju");
            action = false;
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