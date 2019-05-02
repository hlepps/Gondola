using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramwajWsiadac : MonoBehaviour {

    public GameObject scene;


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
            scene.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Tramwaj");
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