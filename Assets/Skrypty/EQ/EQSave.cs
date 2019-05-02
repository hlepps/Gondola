using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EQSave : MonoBehaviour {

    public static int[] EQSlot;
    public static bool start;
    public GameObject EQ;

    // Use this for initialization
    void Start()
    {
        if (!start)
        {
            Debug.Log("Initializing global EQ");
            EQSlot = new int[EQ.GetComponent<EQ>().length];
            start = true;

        }
    } 
        
	
	
	// Update is called once per frame
	void Update () {
		
	}


    public int getItem(int slotID)
    {
        return EQSlot[slotID];
    }

    public void setItem(int slotID, int itemID)
    {
        EQSlot[slotID] = itemID;
    }

}
