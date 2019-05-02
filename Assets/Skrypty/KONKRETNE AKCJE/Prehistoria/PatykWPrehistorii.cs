using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatykWPrehistorii : MonoBehaviour {

    public GameObject eq;
    bool action;
    bool taken;


    void Update()
    {
        


        if (action)
        {
            eq.GetComponent<EQ>().addItem(11);
            taken = true;
            action = false;
        }
    }

    private void OnMouseDown()
    {

        action = true;

    }
}