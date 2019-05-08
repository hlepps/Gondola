using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class Jaskinia : MonoBehaviour {


    public GameObject cam, eq, mouseFollow, gGondola, gKot, gKermit, uga, kotDest, kermitDest, sceneManager, quest, ugaPrzewr;
    public AudioMixer mixer;
    public AudioClip ratunku, dzieki, otsochodzi, czesc, dumny, niewiem, chopaki, uu;

    bool action;

    Kot kot, kermit;
    Gondola gondola;

    void Start () {
        action = true;
        a = true;
        kot = gKot.GetComponent<Kot>();
        kermit = gKermit.GetComponent<Kot>();
        gondola = gGondola.GetComponent<Gondola>();

        ///DEBUG:
        //eq.GetComponent<EQ>().addItem(8);
        ///


    }
    bool klik;
    void OnMouseDown()
    {
        klik = true;
    }
    void OnMouseUp()
    {
        klik = false;
    }

    // Update is called once per frame
    bool a, b, c, d, e, f, g, h, i;
    void Update()
    {
        if (action)
        {
            if (a)
            {
                
                gondola.say("", 5.0f, 0);
                kot.say("RATUUUNKUUU!", 1.0f, 0, ratunku);
                kot.say("POMOOCYYY!", 0.8f, 1);
                kot.say("AŁAAA!", 1.7f, 2);
                kot.say("GONDOLAA RATUUJ!", 1.5f, 3);
                
                if (kot.ResetAction(4))
                {
                    a = false;
                    b = true;
                }
            }
            if (b)
            {
                gondola.say("", 1.0f, 1, uu);
                if (gondola.ResetAction(2))
                {
                    quest.GetComponent<Quest>().newQuest("Uratuj kota");
                    b = false;
                    c = true;
                }

            }
            if (c)
            {
                
                if (mouseFollow.GetComponent<Mouse>().attachedID == 8 && klik)
                {
                    eq.GetComponent<EQ>().delItem(8);
                    c = false;
                    d = true;
                }
            }
            if (d)
            {
                GameJolt.API.Trophies.Unlock(105180, (bool success) => {
                    if (success)
                    {
                        Debug.Log("Success!");
                    }
                    else
                    {
                        Debug.Log("Something went wrong");
                    }
                });
                //przewróc uga
                uga.transform.SetPositionAndRotation(ugaPrzewr.transform.position, ugaPrzewr.transform.rotation);

                d = false;
                e = true;

            }            
            if (e)
            {
                kot.destination(kotDest.transform.position, 0, 3);
                kot.say("Dzięki mordo, znowu mnie uratowałeś", 3.0f, 1, dzieki);
                kot.say("Co teraz robimy?", 2.2f, 2);
                if (kot.ResetAction(3))
                {
                    e = false;
                    f = true;
                }

            }
            if (f)
            {
                kermit.destination(kermitDest.transform.position, 0);
                kermit.say("I co dumny jesteś z siebie kocie?", 3.0f, 1, dumny);
                
                if (kermit.ResetAction(2))
                {
                    kot.say("O co ci chodzi?", 1.3f, 0, otsochodzi);
                    //if (kot.ResetAction(1))
                    //{
                        f = false;
                        g = true;
                    //}
                }
            }
            if (g)
            {
                //kot.say("O co ci chodzi?", 1.3f, 0, otsochodzi);
                kermit.say("Chłopaki", 1.5f, 0, chopaki);
                kermit.say("Mam plan", 1.5f, 1);
                kermit.say("Mam płyte do konsolety co nas stąd zabierze", 3.5f, 2);
                kermit.say("Tylko jest jeden problem", 4.1f, 3);

                if (kermit.ResetAction(4))
                {
                    g = false;
                    h = true;
                }

            }
            if (h && !z)
            {
                Bloom bloomLayer = null;
                ChromaticAberration chromaticAberration = null;
                Grain grain = null;


                PostProcessVolume volume = cam.GetComponent<PostProcessVolume>();
                volume.profile.TryGetSettings(out bloomLayer);
                volume.profile.TryGetSettings(out chromaticAberration);
                volume.profile.TryGetSettings(out grain);


                bloomLayer.enabled.value = true;
                bloomLayer.intensity.value += Time.deltaTime * 50;

                chromaticAberration.enabled.value = true;
                chromaticAberration.intensity.value = Random.Range(0.2f, 0.9f);

                grain.intensity.value = Random.Range(0.4f, 0.9f);
                float w;
                mixer.GetFloat("Rate", out w);
                mixer.SetFloat("Rate", w + Time.deltaTime * 2);

                mixer.GetFloat("RateMusic", out w);
                mixer.SetFloat("RateMusic", w + Time.deltaTime * 1.6f);

                
                kermit.say("Nie wiem gdzie nas zabierze", 2.3f, 0, niewiem);
                
                if (kermit.ResetAction(1))
                {
                    mixer.SetFloat("Rate", 0.0f);
                    mixer.SetFloat("RateMusic", 0.0f);
                    sceneManager.GetComponent<SceneManager>().changeScene(nextScene);
                    z = true;
                }
            }

        }
    }
    public string nextScene;
    bool z;
}

