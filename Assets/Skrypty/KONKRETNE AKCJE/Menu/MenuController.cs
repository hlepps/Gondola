using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {


    public GameObject menu;

    public GameObject[] arty;
    public GameObject[] miejsca;


    public int StartArt;

    public int StartPlace;
    private int endPlace;

    public float fadeSpeed;
    public int steps;
    private Vector2 step = new Vector2(0,0);

    private int didSteps;

    private int layer = 0;


    private Color c;
    private bool starting = true;

	// Use this for initialization
	void Start () {
        if (StartArt == 0) StartArt = Random.Range(0, 14);
        if (StartPlace == 0) StartPlace = Random.Range(0, 4);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (starting)
        {
            didSteps = 0;
            arty[StartArt].transform.Translate(miejsca[StartPlace].transform.position - arty[StartArt].transform.position);

            

            arty[StartArt].GetComponent<SpriteRenderer>().sortingOrder = layer;
            menu.GetComponent<SpriteRenderer>().sortingOrder = layer + 1;
            layer++;


            c = arty[StartArt].GetComponent<SpriteRenderer>().color;
            c.a = 0;
            arty[StartArt].GetComponent<SpriteRenderer>().color = c;

            endPlace = Random.Range(0, 4);
            if (endPlace == StartPlace) endPlace--;
            if (endPlace == -1) endPlace = 3;
            step.x = miejsca[endPlace].transform.position.x / steps;
            step.y = miejsca[endPlace].transform.position.y / steps;
            starting = false;
        }
        
        c = arty[StartArt].GetComponent<SpriteRenderer>().color;
        c.a += fadeSpeed;
        arty[StartArt].GetComponent<SpriteRenderer>().color = c;
        arty[StartArt].transform.Translate(step);
        didSteps++;

        if (didSteps == steps)
        {
            int oldart = StartArt;
            StartArt = Random.Range(0, 14);
            if (oldart == StartArt)
            {
                StartArt--;
                if (StartArt == -1) StartArt = 13;

            }
            StartPlace = Random.Range(0, 4);
            starting = true;
        }



	}
}
