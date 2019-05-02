using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DatBoii : MonoBehaviour {

    private NavMeshAgent m_Agent;
    private RaycastHit m_HitInfo = new RaycastHit();
    private Rigidbody2D rb;

    public GameObject gondola;
    public GameObject pisiont;
    public GameObject boi;

    public bool moving;

    public int currAction;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    public Vector3 whereToGo;

	// Update is called once per frame
	void FixedUpdate () {

        if(boi.transform.position.x <= gondola.transform.position.x)
        {
            pisiont.SetActive(true);
        }

		if(moving)
        {
            /*
                if(facing == "left")
                {
                    transform.localScale.Set(-1, 1, 1);

                }
                else if(facing == "right")
                {
                    transform.localScale.Set(1, 1, 1);
                }

                */

            var ray = Camera.main.ScreenPointToRay(whereToGo);
            if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            {
                m_Agent.destination = m_HitInfo.point;

                //Debug.Log(angle);

                //Debug.Log(kierunek);


            }

            float angle = AngleBetweenVector2(transform.position, m_Agent.destination);



            /*
            if (angle < 180 && angle >= 0) transform.localScale.Set(1, 1, 1);

            else if ((angle < 0 && angle >= -180) || (angle > 135 && angle <= 180)) transform.localScale.Set(-1, 1, 1);
            */
        }
	}


    public void go(/*string facing,*/ Vector3 where, int actionID)
    {
        if (actionID == currAction)
        {
            if (!moving)
            {
                moving = true;
                whereToGo = where;
                
            }




        }

    }

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 difference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, difference) * sign;
    }

    public bool resetAction(int actionID)
    {
        if (currAction == actionID)
        {
            currAction = 0;
            return true;

        }
        else return false;
    }

}
