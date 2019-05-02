using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RytmicznyRuch : MonoBehaviour {

    public float ruch;
    public float bpm;
    public float offset;
    public int startDir;
    
    private float temp;
	// Use this for initialization
	void Start () {
        bpm = 60 / bpm;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (offset <= 0)
        {
            temp += Time.deltaTime;

            if (temp >= bpm)
            {
                switch (startDir)
                {
                    case 0:
                        transform.Translate(0, ruch, 0);
                        startDir++;
                        temp = 0;
                        break;

                    case 1:
                        transform.Translate(ruch, 0, 0);
                        startDir++;
                        temp = 0;
                        break;

                    case 2:
                        transform.Translate(0, -ruch, 0);
                        startDir++;
                        temp = 0;
                        break;

                    case 3:
                        transform.Translate(-ruch, 0, 0);
                        startDir = 0;
                        temp = 0;
                        break;
                }

            }
        }
        else if(offset > 0)
        {
            offset -= Time.deltaTime;
        }
	}
}
