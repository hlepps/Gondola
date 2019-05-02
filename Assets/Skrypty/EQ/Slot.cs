using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public GameObject sprite;
    public GameObject mousePosition;
    public GameObject EQ;
    

    public bool mouseON;
    public bool stickToMouse;

	// Use this for initialization
	void Start () {
        Physics.queriesHitTriggers = true;

    }

    // Update is called once per frame
    void Update() {
        if (sprite != null)
        {
            if (Input.GetMouseButtonDown(0) && mousePosition.GetComponent<Mouse>().attached == null)
            {
                if (mouseON)
                {
                    Debug.Log("Starting drag");
                    mousePosition.GetComponent<Mouse>().attached = sprite;
                    stickToMouse = true;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Cancelling drag");
                stickToMouse = false;
                mousePosition.GetComponent<Mouse>().attached = EQ.GetComponent<EQ>().ItemList[0];
                mousePosition.GetComponent<Mouse>().attached = null;
            }

            if (stickToMouse)
            {
                Debug.Log("Dragging");
                //sprite.transform.position.Set(mousePosition.transform.position.x, mousePosition.transform.position.y, sprite.transform.position.z);
                sprite.transform.Translate(mousePosition.transform.position - sprite.transform.position);
            }
            else if (!stickToMouse)
            {
                //sprite.transform.position.Set(transform.position.x, transform.position.y, sprite.transform.position.z);
                sprite.transform.Translate(transform.position - sprite.transform.position);
            }
        }
            
    }

    public void placeItem(GameObject item)
    {
        sprite = Instantiate(item, transform);
        //EQSlotSprite[i] = ItemList[EQSlot[i]];
        //EQSlotSprite[i].transform.position.Set(EQSlotPlacement[i].transform.position.x, EQSlotPlacement[i].transform.position.y, EQSlotPlacement[i].transform.position.z);
        sprite.GetComponent<SpriteRenderer>().enabled = true;
        sprite.transform.SetParent(transform);
        //EQSlot[i].transform.position.Set(0, 0, 0);
        sprite.GetComponent<SpriteRenderer>().sortingOrder = 1002;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered a slot");
        mouseON = true;
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse exitted a slot");
        mouseON = false;
    }
}
