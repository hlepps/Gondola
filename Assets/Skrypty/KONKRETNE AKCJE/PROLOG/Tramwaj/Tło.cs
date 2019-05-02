using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tło : MonoBehaviour {

    public bool SWITCH;
    private bool p;
    public Vector3 start, end;
    public float speed;

    private bool fertig;
    private bool slow;

    public float startSpeed = 0.1f;
    public float lerp = 0.0f;
    public float finalSpeed;
    public float przyspieszenie;
    public float przysp;
    // Use this for initialization
    void Start () {
        start = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(SWITCH)
        {
            if (!p)
            {
                fertig = true;
                slow = false;
                przysp = przyspieszenie;
                p = true;
                SWITCH = false;
            }
            else if (p)
            {
                fertig = false;
                slow = true;
                przysp = przyspieszenie;
                p = false;
                SWITCH = false;
            }
        }

        if (fertig)
        {
            finalSpeed = Mathf.Lerp(startSpeed, speed, lerp);
            przysp *= 1.01f;
            lerp += Time.deltaTime * przysp;
            if (lerp >= 1) lerp = 1;
            transform.Translate(-Time.deltaTime * finalSpeed, 0, 0);
            if (transform.position.x <= end.x)
            {
                przysp = 0;
                transform.Translate(start - transform.position);
            }
        }
        if(!fertig)
        {
            if(slow)
            {
                finalSpeed = Mathf.Lerp(startSpeed, speed, lerp);
                przysp *= 1.01f;
                //if (przysp > 0) przysp *= -1;
                lerp -= Time.deltaTime * przysp;
                if (lerp <= 0) lerp = 0;
                transform.Translate(-Time.deltaTime * finalSpeed, 0, 0);
                if (transform.position.x <= end.x)
                {
                    przysp = 0;
                    transform.Translate(start - transform.position);
                }
            }
        }
	}
}
