using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour {

	GameObject global;
	GameObject EQ;
    public void Awake()
    {
        global = GameObject.FindGameObjectWithTag("Global");
        EQ = GameObject.FindGameObjectWithTag("EQ");
    }
	public Checker()
	{
		

        global.GetComponent<Global>().setGonbool(9990 - GetComponent<ItemID>().ID, false);
        global.GetComponent<Global>().SetGonboolName(9990 - GetComponent<ItemID>().ID, this.gameObject.name);

        if (EQ.GetComponent<EQ>().IsThereItem(GetComponent<ItemID>().ID))
        {
            Debug.Log("thereis item");
            global.GetComponent<Global>().setGonbool(9990 - GetComponent<ItemID>().ID, true);
            global.GetComponent<Global>().SetGonboolName(9990 - GetComponent<ItemID>().ID, this.gameObject.name);
        }


        if (global.GetComponent<Global>().getGonbool(9990 - GetComponent<ItemID>().ID))
        {
            Debug.Log(this.gameObject.name + " : false ");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(this.gameObject.name + " : true");
            this.gameObject.SetActive(true);
        }

    }
	

    void Update()
    {
        if(EQ.GetComponent<EQ>().IsThereItem(GetComponent<ItemID>().ID))
        {
            Debug.Log("thereis item");
            global.GetComponent<Global>().setGonbool(9990-GetComponent<ItemID>().ID, true);
            global.GetComponent<Global>().SetGonboolName(9990-GetComponent<ItemID>().ID, this.gameObject.name);
        }


        if (global.GetComponent<Global>().getGonbool(9990 - GetComponent<ItemID>().ID))
        {
            Debug.Log(this.gameObject.name + " : false ");
            this.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(this.gameObject.name + " : true");
            this.gameObject.SetActive(true);
        }
    }
}
