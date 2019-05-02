using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemID : MonoBehaviour {

    public int ID;

    GameObject global, eq;

    
    void Start()
    {
        global = GameObject.FindGameObjectWithTag("Global");
        eq = GameObject.FindGameObjectWithTag("EQ");
    }

    
    
}
