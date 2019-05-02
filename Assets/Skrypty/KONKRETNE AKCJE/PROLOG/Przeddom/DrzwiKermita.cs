using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrzwiKermita : MonoBehaviour {

    public GameObject gondola, kot, quest, global, klikkot, ahus, drabina, nowaDrabina, staraDroga, nowaDroga, idztam, domKermita, scenem;
    //public GameObject mouseFollow;
    public float distance;
    public AudioClip[] ejej;
    public string[] text;
    public AudioClip chonotu, pomoz, dziena, nieumiesz, umiem;
    public Sprite otwarty;

    bool endkot;
    bool action;
    // Use this for initialization
    public static bool got;
    void activate()
    {
        if(!got)
        {
            GameJolt.API.Trophies.Unlock(103688, (bool success) => {if (success)
                    {
                        Debug.Log("Success!");
                    }
                    else
                    {
                        Debug.Log("Something went wrong");
                    }
                });
                got = true;
        }
    }
    void Start () {
        quest.GetComponent<Quest>().newQuest("Wejdź do domu kaczki");
	}
    float temp = 10.0f;
    bool don = false;
    void Update()
    {
        if(global.GetComponent<Global>().getGonbool("uratowanoKota"))
        {
            action = false;
            nowaDrabina.SetActive(true);
            Destroy(staraDroga);
            nowaDroga.SetActive(true);
            kot.GetComponent<Kot>().currentAction = 0;
            endkot = true;
            global.GetComponent<Global>().setGonbool("uratowanoKota", false);
        }

        if(endkot)
        {
            activate();
            
            kot.GetComponent<Kot>().say("Ej mordo, dzięki że mi pomogłeś zejść z tego drzewa, wiesz?", 3.0f, 0, dziena);
            kot.GetComponent<Kot>().say("Co? Drzwi nie mozesz otworzyc?", 2.0f, 1, nieumiesz);
            kot.GetComponent<Kot>().say("Dawaj, ja je otworze!", 1.0f, 2, umiem);
            kot.GetComponent<Kot>().destination(idztam.transform.position, 3);
            if(kot.GetComponent<Kot>().ResetAction(4))
            {
                global.GetComponent<Global>().setGonbool("wchodziKermit", true);
                endkot = false;
                domKermita.GetComponent<SpriteRenderer>().sprite = otwarty;
            }
        }


        if (action)
        {
            if(global.GetComponent<Global>().getGonbool("uratowanoKota"))
                {
                    // teleport do domu kermita
                }
            if (global.GetComponent<Global>().getGonbool("zapukanoKermit"))
            {
                //Debug.Log(ejej.Length);
                for (int i = 0; i < ejej.Length; i++)
                {
                    //Debug.Log(i);
                    int x = Random.Range(0, 7);
                    kot.GetComponent<Kot>().say(text[x], 2.0f, i, ejej[x]);
                }
                if (kot.GetComponent<Kot>().ResetAction(ejej.Length))
                {
                    //action = false;
                }
            }


            if (klikkot.GetComponent<KlikNaKota>().click && !global.GetComponent<Global>().getGonbool("ahusPrzeddom"))
            {
                Debug.Log("click na kota");
                global.GetComponent<Global>().setGonbool("zapukanoKermit", false);
                global.GetComponent<Global>().setGonbool("klikKot", true);
                kot.GetComponent<Kot>().currentAction = 0;
            }

            if(global.GetComponent<Global>().getGonbool("klikKot") && !global.GetComponent<Global>().getGonbool("ahusPrzeddom"))
            {
                Debug.Log("sprawdzam dalej");
                kot.GetComponent<Kot>().say("Gościu! Gościu! Chodźtu na chwile!", 2.0f, 0, chonotu);
                kot.GetComponent<Kot>().say("We mi pomóż zejść", 3.0f, 1, pomoz);
                if(kot.GetComponent<Kot>().ResetAction(2))
                {
                    global.GetComponent<Global>().setGonbool("klikKot", false);
                    global.GetComponent<Global>().setGonbool("ahusPrzeddom", true);
                    ahus.GetComponent<AhusPrzeddom>().spadlo = false;


                }
            }

            

            if(global.GetComponent<Global>().getGonbool("ahusPrzeddom"))
            {
                Debug.Log(temp);
                Debug.Log("ahus " + ahus.GetComponent<AhusPrzeddom>().spadlo);
                temp -= Time.deltaTime;
                
                drabina.SetActive(true);

                if (temp <= 8.6f && !don && temp >= 6.1f)
                {
                    drabina.GetComponent<AudioSource>().Play();
                    don = true;
                }

                if (temp <= 6.0f && don)
                {
                    
                    ahus.GetComponent<AhusPrzeddom>().spadlo = true;
                    don = false;
                }

                

                if (temp <= 0)
                {
                    ahus.GetComponent<AhusPrzeddom>().spadlo = false;
                    quest.GetComponent<Quest>().newQuest("Uratuj kota");
                    global.GetComponent<Global>().setGonbool("ahusPrzeddom", false);
                    global.GetComponent<Global>().setGonbool("startPrzeddom", true);
                }

                
            }

            
        }
    }

    private void OnMouseDown()
    {
        if (!global.GetComponent<Global>().getGonbool("zapukanoKermit") && !global.GetComponent<Global>().getGonbool("wchodziKermit")) global.GetComponent<Global>().setGonbool("zapukanoKermit", true);

        if (Vector2.Distance(transform.position, gondola.transform.position) <= distance)
        {
            if(domKermita.GetComponent<SpriteRenderer>().sprite == otwarty) scenem.GetComponent<SceneManager>().changeScene("Sceny/Prolog/DomKaczki");
            action = true;
        }
    }
}
