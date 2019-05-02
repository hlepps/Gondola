using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {

    public GameObject attached;
    public int attachedID;

    private string text;

    public GameObject TextObject;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TextObject.GetComponent<TMPro.TextMeshPro>().text = text;
        if (attached == null)
        {
            attachedID = 0;
        }
        else {
            attachedID = attached.GetComponent<ItemID>().ID;
        }


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Collides!!" + other.gameObject.name);
        if (!other.GetComponent<Name>().disabled)
        {
            if (attached != null)
            {
                text = attached.GetComponent<Name>().thisname + " + " + other.GetComponent<Name>().thisname;
                if (other.GetComponent<Name>().thisname == null)
                {
                    text = "";
                }
            }
            else
            {
                text = other.GetComponent<Name>().thisname;
                if (other.GetComponent<Name>().thisname == null)
                {
                    text = "";
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        text = "";
    }

}
