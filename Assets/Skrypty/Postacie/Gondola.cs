
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


    public class Gondola : MonoBehaviour
    {

        public GameObject Global;

        public GameObject glowa;
        public GameObject nogaPrawa;
        public GameObject nogaDolnaPrawa;
        public GameObject stopaPrawa;
        public GameObject nogaLewa;
        public GameObject nogaDolnaLewa;
        public GameObject stopaLewa;

        public GameObject gondolaAnim;
        public GameObject gondolaAnimnogaPrawa;
        public GameObject gondolaAnimnogaDolnaPrawa;
        public GameObject gondolaAnimstopaPrawa;
        public GameObject gondolaAnimnogaLewa;
        public GameObject gondolaAnimnogaDolnaLewa;
        public GameObject gondolaAnimstopaLewa;




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
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            m_Agent = GetComponent<NavMeshAgent>();

        }

        // Update is called once per frame
        void Update()
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

        private float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
        {
            Vector2 difference = vec2 - vec1;
            float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
            return Vector2.Angle(Vector2.right, difference) * sign;
        }
        float angle;

        private void FixedUpdate()
        {
           

            float dr = farScale + (nearScale - farScale) * (-transform.position.y * scaleMultiplier);
            transform.localScale = new Vector3(dr, dr, dr);

            glowa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 0);
            nogaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            nogaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            stopaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            nogaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 5);
            nogaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 3);
            stopaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 4);

            gondolaAnim.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 0);
            gondolaAnimnogaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            gondolaAnimnogaDolnaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 1);
            gondolaAnimstopaPrawa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 2);
            gondolaAnimnogaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 5);
            gondolaAnimnogaDolnaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 3);
            gondolaAnimstopaLewa.GetComponent<SpriteRenderer>().sortingOrder = (int)((transform.position.y * orderMultiplier) + 4);
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift) && !saying && !animationing && !Global.GetComponent<Global>().paused && !Global.GetComponent<Global>().waiting)
            {
            Debug.Log(Global.GetComponent<Global>().waiting + " = waiting");
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                {
                    m_Agent.destination = m_HitInfo.point;

                    //Debug.Log(angle);

                    //Debug.Log(kierunek);
                    angle = AngleBetweenVector2(transform.position, m_HitInfo.point);

                    if(!customKierunek)
                    {
                        if (angle < 135 && angle >= 45) kierunek = 0;    // GORA
                        else if (angle < 45 && angle >= -45) kierunek = 1; // PRAWO
                        else if (angle < -45 && angle >= -135) kierunek = 2; // DOL
                        else if ((angle < -135 && angle >= -180) || (angle > 135 && angle <= 180)) kierunek = 3; // LEWO
                    }

                }
            }
            else if (going)
            {
                if (Vector3.Distance(transform.position, m_Agent.destination) < distance)
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
                    currentAction++;
                    saying = false;
                }

            }


            glowa.GetComponent<Animator>().SetInteger("Direction", kierunek);
        }

        public float animsecs;
        public bool animBef = false;

        public void stopAnim(int number)
        {
            if (number == currentAction)
            {
                Debug.Log("Ending Animation");
                animBef = false;
                glowa.SetActive(true);
                gondolaAnim.SetActive(false);
                animationing = false;
                currentAction++;
            }
        }
        public void playAnim(AnimationClip anim, int number)
        {

            if (number == currentAction)
            {
                if (!animBef)
                {
                    Debug.Log(anim.length);
                    animsecs = (float)anim.length;
                    animBef = true;
                    glowa.SetActive(false);
                    gondolaAnim.SetActive(true);
                    gondolaAnim.GetComponent<Animation>().clip = anim;
                    gondolaAnim.GetComponent<Animation>().Play();
                    animationing = true;
                }

                animsecs -= Time.deltaTime;


                //Debug.Log(animsecs);

                if (animsecs < 0.0f)
                {
                    Debug.Log("Ending Animation");
                    animBef = false;
                    glowa.SetActive(true);
                    gondolaAnim.SetActive(false);
                    animationing = false;
                    currentAction++;

                }
            }
        }

        public void say(string text, float time, int number, AudioClip audioclip)
        {

            if (saying == false && currentAction == number)
            {
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

        public void destination(Vector2 destination, int number)
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
                Debug.Log("XX");
                customKierunek = true;
                kierunek = kierunekRuchu;
                going = true;
                m_Agent.destination = destination;

            }
        }

        public bool ResetAction(int numberToReset)
        {
            if (currentAction == numberToReset)
            {
                Debug.Log("ReSettingAction");
                glowa.SetActive(true);
                gondolaAnim.SetActive(false);
                currentAction = 0;
                customKierunek = false;
                return true;
            }
            else return false;
        }


    }
