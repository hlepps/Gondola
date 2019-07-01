using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kot : MonoBehaviour {


    public GameObject Global;

    public GameObject tors;
    public GameObject glowa;
    public GameObject nogaPrawa;
    public GameObject nogaDolnaPrawa;
    public GameObject rekaPrawa;
    public GameObject rekaDolnaPrawa;
    public GameObject nogaLewa;
    public GameObject nogaDolnaLewa;
    public GameObject rekaLewa;
    public GameObject rekaDolnaLewa;

    public GameObject WalkSound;

    public GameObject go_to;

    public GameObject text;

    public GameObject sceneManager;

    public int orderMultiplier;
    //public float scaleMultiplier;
    public int currentAction = 0;
    public float distance;

    public float nearScale;
    public float farScale;
    public float scaleMultiplier;

    private Vector3 move;
    private Rigidbody2D rb;
    private bool saying = false;
    private string toSay;
    private float timeToSay;
    private float timeTemp;
    private bool going;
    private bool animationing;

    public int kierunek;
    private int destKierun;

    private NavMeshAgent m_Agent;
    private RaycastHit m_HitInfo = new RaycastHit();
    private bool doing;
    private Vector3 startpos;
    private Vector3 nullpos;

    private Vector2 goingDest;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Agent = GetComponent<NavMeshAgent>();
        kierunek = 2;

        if (moveOff)
        {
            m_Agent.enabled = false;
            transform.Rotate(-90, 0, 0);
        }
    }

    private void Update()
    {
        if (startpos != nullpos)
        {
            if (transform.position == startpos)
            {
                glowa.GetComponent<Animator>().SetBool("Ruch", false);
                WalkSound.GetComponent<AudioSource>().mute = true;
            }
            else
            {
                glowa.GetComponent<Animator>().SetBool("Ruch", true);
                WalkSound.GetComponent<AudioSource>().mute = false;
            }
        }
        startpos = transform.position;
    }

    public bool moveOff;

    private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 difference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector2.Angle(Vector2.right, difference) * sign;
    }
    float angle;

    // Update is called once per frame
    void FixedUpdate () {

        if (moveOff)
        {
            m_Agent.enabled = false;
        }
        if (!moveOff)
        {
            m_Agent.enabled = true;
        }

        float dr = farScale + (nearScale - farScale) * (-transform.position.y * scaleMultiplier);
        transform.localScale = new Vector3(dr, dr, dr);

        if(kierunek == 1)
        {
            nogaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 9);
            nogaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 8);
            rekaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 9);
            rekaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 8);
            
            glowa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 7);
            tors.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 6);

            nogaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            nogaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            rekaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            rekaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
        }
        else if(kierunek == 3)
        {
            nogaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            nogaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            rekaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            rekaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);

            glowa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 7);
            tors.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 6);

            nogaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 9);
            nogaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 8);
            rekaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 9);
            rekaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 8);
        }
        else
        {
            glowa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 7);
            tors.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 6);

            nogaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            nogaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            rekaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            rekaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            nogaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 5);
            nogaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 3);
            rekaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 3);
            rekaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
        }

           

        if (!saying && !animationing && !Global.GetComponent<Global>().paused && !Global.GetComponent<Global>().waiting && !moveOff)
        {

            ///
            // MYSZKA
            //var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
            //{
                //m_Agent.destination = m_HitInfo.point;

                //Debug.Log(angle);

                //Debug.Log(kierunek);

                // KONIEC
                ///

                angle = AngleBetweenVector2(transform.position, m_HitInfo.point);

                float dist = Vector3.Distance(transform.position, m_Agent.destination);
                if(go_to != null) //Debug.Log("Distance from " + this.gameObject.name + " to " + go_to.gameObject.name + " equals " + dist);
            
                if(!customKierunek)
                {
                    if (angle < 135 && angle >= 45) kierunek = 0;    // GORA
                    else if (angle < 45 && angle >= -45) kierunek = 1; // PRAWO
                    else if (angle < -45 && angle >= -135) kierunek = 2; // DOL
                    else if ((angle < -135 && angle >= -180) || (angle > 135 && angle <= 180)) kierunek = 3; // LEWO
                }

            //}

        }
        if (going)
        {
            float dist = Vector2.Distance(transform.position, m_Agent.destination);
            Debug.Log(dist);
            if (dist < distance)
            {
                currentAction++;
                going = false;
            }
        }

        if (currentAction != 0)
        {
            doing = true;
            
        }

        if (saying)
        {
            text.GetComponent<TMPro.TextMeshPro>().text = toSay;
            timeTemp += Time.deltaTime;
            if (timeTemp >= timeToSay)
            {
                text.GetComponent<TMPro.TextMeshPro>().text = " ";
                timeTemp = 0;
                saying = false;
                currentAction++;
                //doing = false;
                
            }

        }

        glowa.GetComponent<Animator>().SetInteger("Direction", kierunek);
    }

    public void ShutUp(int number)
    {
        if(currentAction == number)
        {
            GetComponent<AudioSource>().mute = true;
            currentAction++;
        }
    }

    public void say(string text, float time, int number, AudioClip audioclip)
    {

        if (saying == false && currentAction == number)
        {
            GetComponent<AudioSource>().mute = false;
            GetComponent<AudioSource>().clip = audioclip;
            GetComponent<AudioSource>().Play();
            toSay = text;
            timeToSay = time;
            saying = true;

        }
    }

    public void say(string text, float time, int number)
    {

        if (saying == false && currentAction == number)
        {
            toSay = text;
            timeToSay = time;
            saying = true;

        }
    }

    public void destination(Vector3 destination, int number)
    {

        if (number == currentAction && going == false)
        {
            going = true;
            m_Agent.destination = destination;

        }
    }

    public bool customKierunek;

    public void destination(Vector2 destination, int number, int kierunekRuchu)
    {
        
        if (number == currentAction && going == false)
        {
            Debug.Log("Kierunek " + this.gameObject.name + " " + kierunekRuchu + " (" + kierunek + ")");
            customKierunek = true;
            kierunek = kierunekRuchu;
            going = true;
            Debug.Log(this.gameObject.name);
            m_Agent.destination = destination;

        }
    }

    public bool ResetAction(int numberToReset)
    {
        if (currentAction == numberToReset)
        {
            Debug.Log("ReSettingAction");
            currentAction = 0;
            customKierunek = false;
            return true;
            
        }
        else return false;
    }


}


