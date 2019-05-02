using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Słonecznik : MonoBehaviour {

    int number;
    bool action;
    public float distance;
    public GameObject global, gondola, eq, skorpion;
    public AudioClip plum;

    void Update()
    {
        if (action)
        {
            if (number == 0)
            {
                gondola.GetComponent<Gondola>().say("", 0.2f, 0, plum);
                if (gondola.GetComponent<Gondola>().ResetAction(1))
                {
                    Destroy(skorpion);
                    eq.GetComponent<EQ>().addItem(8);
                    action = false;
                    number++;
                }
                
            }
            else if (number == 1)
            {
                gondola.GetComponent<Gondola>().say("", 0.2f, 0, plum);
                if (gondola.GetComponent<Gondola>().ResetAction(1))
                {
                    eq.GetComponent<EQ>().addItem(9);

                    action = false;
                    number++;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
        
            action = true;
          
        }
    }
}
