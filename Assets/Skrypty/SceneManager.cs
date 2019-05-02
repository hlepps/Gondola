using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject audio;

    public GameObject cam;

    public string scene;

    public static string actualScene;

    public string GetActualScene()
    {
        return actualScene;
    }

    bool change;

    bool start;

    Color tmp;

	// Use this for initialization
	void Start () {
        cam = GameObject.FindWithTag("MainCamera");

        transform.position.Set(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 1);
        
        tmp = GetComponent<SpriteRenderer>().color;
        tmp.a = 1.2f;
        GetComponent<SpriteRenderer>().color = tmp;
        start = true;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(start)
        {
            
            tmp.a -= Time.deltaTime;

            //Debug.Log(tmp.a);

            GetComponent<SpriteRenderer>().color = tmp;
            audio.GetComponent<AudioSource>().volume = 1-tmp.a;


            if (tmp.a <= 0.1)
            {
                transform.position.Set(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 5000);
                tmp.a = 0;
                GetComponent<SpriteRenderer>().color = tmp;
                audio.GetComponent<AudioSource>().volume = 1;

                start = false;
            }
        }

		if(change)
        {
            tmp.a += Time.deltaTime;

            Debug.Log(tmp.a);

            GetComponent<SpriteRenderer>().color = tmp;
            audio.GetComponent<AudioSource>().volume = 1-tmp.a;

            if (tmp.a >= 0.99)
            {
                if (scene == "EXIT")
                {
                    Application.Quit();
                }
                else
                {
                    Application.LoadLevel(scene);
                    change = false;
                }
            }
        }
	}

    public void changeScene(string sceneName)
    {
        transform.position.Set(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 1);
        
        tmp = GetComponent<SpriteRenderer>().color;
        scene = sceneName;
        actualScene = sceneName;
        change = true;
    }

    public void ExitGame()
    {
        transform.position.Set(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 1);

        tmp = GetComponent<SpriteRenderer>().color;
        scene = "EXIT";
        change = true;
    }

    public void changeMusic(AudioClip clip)
    {
        if(audio.GetComponent<AudioSource>().clip != clip)
        {

            audio.GetComponent<AudioSource>().clip = clip;
            audio.GetComponent<AudioSource>().Play();
        }
    }



}
