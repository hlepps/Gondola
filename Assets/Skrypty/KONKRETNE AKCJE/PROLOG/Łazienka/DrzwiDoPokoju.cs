using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrzwiDoPokoju : MonoBehaviour {

    public GameObject gondola;
    public GameObject przejscie;
    public GameObject sceneManager;
    public float distance;
    public AudioClip audioclip;

    private bool action;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            gondola.GetComponent<Gondola>().say("He He He", 1.5f, 0, audioclip);
            przejscie.GetComponent<Pokoj_Lazienka>().setStatic(true);
            
            if (gondola.GetComponent<Gondola>().ResetAction(1))
            {
                action = false;
                sceneManager.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Pokoj Gondoli");
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log(Vector2.Distance(transform.position, gondola.transform.position));
        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            action = true;
        }
    }
}
