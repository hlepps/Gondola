using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQ : MonoBehaviour {

    public int length;

    public GameObject Global;
    

    public GameObject[] EQSlotPlacement;

    public GameObject[] ItemList;

    public GameObject mouseFollow;
    public GameObject audio;
    


    public float bounce;
    public float full;
    public float speed;

    private float timer;
    private bool over, show;

    private Vector3 startPos;
    



    // Use this for initialization
    void Start () {
        

        startPos = transform.localPosition;
        Debug.Log(startPos);
        if (EQSave.start)
        {
            for (int i = 0; i < length; i++)
            {


                if (EQSave.EQSlot[i] == 0)
                {
                    Debug.Log(i + " is null!!");


                }
                else if (EQSave.EQSlot[i] != 0)
                {
                    Debug.Log(EQSave.EQSlot[i]);
                    EQSlotPlacement[i].GetComponent<Slot>().placeItem(ItemList[EQSave.EQSlot[i]]);

                }
            }
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {

        for(int i = 0; i < length; i++)
        {
            if (EQSave.EQSlot[i] != 0)
            {
                //EQSlotSprite[i].transform.position.Set(EQSlotPlacement[i].transform.position.x, EQSlotPlacement[i].transform.position.y, EQSlotPlacement[i].transform.position.z);
            }
        }

        

        if(over && !Global.GetComponent<Global>().paused)
        {
            Global.GetComponent<Global>().waiting = true;

            Debug.Log("OVER");

            if (timer >= bounce)
            {
                //timer = 0;
                //over = false;
                if (show)
                {
                    
                    if (timer >= full)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            EQSlotPlacement[i].transform.localPosition.Set(EQSlotPlacement[i].transform.localPosition.x, EQSlotPlacement[i].transform.localPosition.y, -1);
                            
                        }
                    }
                    else
                    {
                        timer += Time.deltaTime * speed;
                        for (int i = 0; i < length; i++)
                        {
                            EQSlotPlacement[i].transform.localPosition.Set(EQSlotPlacement[i].transform.localPosition.x, EQSlotPlacement[i].transform.localPosition.y, 1);
                        }
                        transform.Translate(0, -Time.deltaTime * speed, 0);
                    }
                }
            }
            else
            {
                timer += Time.deltaTime * speed;
                for (int i = 0; i < length; i++)
                {
                    EQSlotPlacement[i].transform.localPosition.Set(EQSlotPlacement[i].transform.localPosition.x, EQSlotPlacement[i].transform.localPosition.y, 1);
                }
                transform.Translate(0, -Time.deltaTime * speed, 0);
            }

        }
        if(!over)
        {
            Global.GetComponent<Global>().waiting = false;
            bool asdf = false;
            for (int i = 0; i < length; i++)
            {
                if (EQSlotPlacement[i].GetComponent<Slot>().mouseON)
                {
                    over = true;
                    asdf = true;
                    break;
                }
            }
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
        show = true;
        audio.GetComponent<AudioSource>().Play();
    }

    public bool IsThereItem(int id)
    {
        for (int i = 0; i < length; i++)
        {
            if(EQSave.EQSlot[i] == id)
                return true;
        }
        return false;

    }

    public void addItem(GameObject item)
    {
        for (int i = 0; i < length; i++)
        {
            
            if(EQSave.EQSlot[i] == 0)
            {
                EQSave.EQSlot[i] = item.GetComponent<ItemID>().ID;
                Debug.Log("ID: " + EQSave.EQSlot[i]);
                EQSlotPlacement[i].GetComponent<Slot>().placeItem(ItemList[item.GetComponent<ItemID>().ID]);
                i = length;

                Global.GetComponent<Global>().setGonbool(9990 - item.GetComponent<ItemID>().ID, true);
            }
            
        }
    }
    public void addItem(int itemID)
    {
        for (int i = 0; i < length; i++)
        {

            if (EQSave.EQSlot[i] == 0)
            {
                EQSave.EQSlot[i] = itemID;
                Debug.Log("ID: " + EQSave.EQSlot[i]);
                EQSlotPlacement[i].GetComponent<Slot>().placeItem(ItemList[itemID]);
                i = length;

                Global.GetComponent<Global>().setGonbool(9990 - itemID, true);
            }

        }
    }

    public void delItem(int id)
    {
        for (int i = 0; i < length; i++)
        {

            if (EQSave.EQSlot[i] == id)
            {
                EQSave.EQSlot[i] = 0;
                EQSlotPlacement[i].GetComponent<Slot>().placeItem(ItemList[0]);
                i = length;

                Destroy(mouseFollow.GetComponent<Mouse>().attached);
                mouseFollow.GetComponent<Mouse>().attached = null;
                for (int y = 0; y < length; y++)
                {
                    EQSlotPlacement[y].GetComponent<Slot>().mouseON = false;
                    EQSlotPlacement[y].GetComponent<Slot>().stickToMouse = false;
                }

            }

        }
    }

    public void delItem(GameObject item)
    {
        for (int i = 0; i < length; i++)
        {

            if (EQSave.EQSlot[i] == item.GetComponent<ItemID>().ID)
            {
                EQSave.EQSlot[i] = 0;
                EQSlotPlacement[i].GetComponent<Slot>().placeItem(ItemList[0]);
                i = length;

                Destroy(mouseFollow.GetComponent<Mouse>().attached);
                mouseFollow.GetComponent<Mouse>().attached = null;
                for (int y = 0; y < length; y++)
                {
                    EQSlotPlacement[y].GetComponent<Slot>().mouseON = false;
                    EQSlotPlacement[y].GetComponent<Slot>().stickToMouse = false;
                }

            }

        }
    }
}
