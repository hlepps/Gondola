using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomKermitaStart : MonoBehaviour {

	bool action;

	public GameObject kermit, gondola, hereA, hereB, hereC, gondolhere, szafa, sceneManager;
	public Sprite otwartaSzafa;
	public AudioClip jestescie, sluchaj, pomoc, skradziono, jako, eh, zaraz, nietu, chono;

	// Use this for initialization
	void Start () {
		action = true;
	}
	bool a,b,c;
	// Update is called once per frame
	void Update () {
		
		if(action)
		{
			if(!a){
				kermit.GetComponent<Kot>().say("O, jesteście!", 4.0f, 0, jestescie);
				kermit.GetComponent<Kot>().say("Słuchaj Gondola, jest taka sprawa", 5.0f, 1, sluchaj);
				kermit.GetComponent<Kot>().say("Potrzebuję pomocy", 3.0f, 2, pomoc);
				kermit.GetComponent<Kot>().say("Skradziono mi płytę", 4.0f, 3, skradziono);
				
				if(kermit.GetComponent<Kot>().ResetAction(4) || a)
				{
					a = true;

				}
			}

			if(a)
			{
				if(!b){
				gondola.GetComponent<Gondola>().say("Jaką płytę?", 3.0f, 0, jako);
				gondola.GetComponent<Gondola>().destination(gondolhere.transform.position, 1, 3);
				}
				if(gondola.GetComponent<Gondola>().ResetAction(2) || b)
				{
					b = true;
					
				}
			}

			if(b)
			{
				if(!c){
					kermit.GetComponent<Kot>().say("ehhh...", 5.0f, 0, eh);
					kermit.GetComponent<Kot>().say("Zaraz wam wszysstko wyjaśnię!", 4.0f, 1, zaraz);
					kermit.GetComponent<Kot>().say("Ale nie tutaj!", 4.0f, 2, nietu);
					kermit.GetComponent<Kot>().say("Chodźcie za mną", 4.0f, 3, chono);
					kermit.GetComponent<Kot>().destination(hereA.transform.position, 4, 2);
					kermit.GetComponent<Kot>().destination(hereB.transform.position, 5, 1);
					kermit.GetComponent<Kot>().destination(hereC.transform.position, 6, 0);
					}
					if(kermit.GetComponent<Kot>().ResetAction(7))
					{
						c = true;
						szafa.GetComponent<SpriteRenderer>().sprite = otwartaSzafa;
                        sceneManager.GetComponent<SceneManager>().changeScene(scene);
					}
			}
		}	
	}
    public string scene;
}
