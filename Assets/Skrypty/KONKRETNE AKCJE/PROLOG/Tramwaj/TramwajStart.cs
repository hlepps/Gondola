using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramwajStart : MonoBehaviour {

    public GameObject gondol, kanar, mouseFollow, eq, scene, tlo;

    public AudioClip ac, ac2;

    public float distance;

    bool action;

    void Start()
    {
        tlo.GetComponent<Tło>().SWITCH = true;
        //eq.GetComponent<EQ>().addItem(4);
    }


    bool ok;
    // Update is called once per frame
    void Update()
    {
        if (action)
        {
            kanar.SetActive(true);
            kanar.GetComponent<Kanar>().say("Bileciki do kontroli", 5.0f, 0, ac);
            if (mouseFollow.GetComponent<Mouse>().attachedID == 4 || ok)
            {
                ok = true;
                if (ok)
                {
                    kanar.GetComponent<Kanar>().say("Świeżo kupiony, proszę bardzo", 2.5f, 1, ac2);
                    kanar.GetComponent<Kanar>().say("Proszę oto pisiont groszy w nagrodę!", 2.5f, 2, ac2);
                }

                
                if (kanar.GetComponent<Kanar>().ResetAction(3))
                {
                    eq.GetComponent<EQ>().addItem(5);
                    tlo.GetComponent<Tło>().SWITCH = true;
                    scene.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Przeddom");
                }
            }
            else
            {
                kanar.GetComponent<Kanar>().say("No to będzie mandacik!", 2.5f, 1, ac2);
                
                if (kanar.GetComponent<Kanar>().ResetAction(2))
                {
                    eq.GetComponent<EQ>().addItem(6);
                    tlo.GetComponent<Tło>().SWITCH = true;
                    scene.GetComponent<SceneManager>().changeScene("Sceny/Prolog/Przeddom");
                    Destroy(this.gameObject);
                }
            }

            

                
        }
    }

    private void OnMouseDown()
    {

        if (Vector2.Distance(transform.position, gondol.transform.position) <= distance)
        {
        action = true;
        }
    }

}