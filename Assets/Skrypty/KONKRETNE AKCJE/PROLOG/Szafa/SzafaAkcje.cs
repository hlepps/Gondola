using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;


public class SzafaAkcje : MonoBehaviour {

	public AudioMixer mixer;
	public GameObject gKot, gGondola, gKermit, sceneManager, cam;
	public AudioClip dizejow, jaCiDam, ej, nieBedziemy, mniejsza, puszczajDapstep, taa, zostawTo;

	Kot kot, kermit;
	Gondola gondola;

	bool action;
	
	void Start () {
		action = true;
		a = true;
		kot = gKot.GetComponent<Kot>();
		kermit = gKermit.GetComponent<Kot>();
		gondola = gGondola.GetComponent<Gondola>();
	}
	
	bool a,b,c,d,e,f,g,h,i;
	void Update () {
		if(action)
		{
			if(a)
			{
				kermit.say("Ej Gondola, co to za sierściuch?", 3.0f, 0, ej);
				if(kermit.ResetAction(1))
				{
					a = false;
					b = true;
				}
			}
			if(b)
			{
				kot.say("Ja ci dam sierściuch!", 1.5f, 0, jaCiDam);
				kot.say("Jestem rasowym kotem brytyjskim!", 2.0f, 1);
				if(kot.ResetAction(2))
				{
					b = false;
					c = true;
				}
			}
			if(c)
			{
				gondola.say("", 1.5f, 0);
				gondola.say("T a a", 3.0f, 1, taa);
				if(gondola.ResetAction(2))
				{
					c=false;
					d=true;
				}
			}
			if(d)
			{
				kermit.say("Mniejsza", 1.0f, 0, mniejsza);
				kermit.say("Nie zebrałem was tu bez powodu", 2.2f, 1);
				kermit.say("To magiczne urządzenie, zwane Konsoletą Didżejów", 3.5f, 2);
				kermit.say("Cokolwiek to znaczy", 1.2f, 3);
				kermit.say("Kupiłem na bazarze za dwie dyszki", 2.5f, 4);
				if(kermit.ResetAction(5))
				{
					d=false;
					e=true;
				}
			}
			if(e)
			{
				kot.say("Diżejów?", 1.22f, 0, dizejow);
				kot.say("To gdzie tu się puszcza dapstep?", 2.0f, 1);
				if(kot.ResetAction(2))
				{
					e=false;
					f=true;
				}

			}
			if(f)
			{
				kermit.say("Nie, nie będziemy puszczać dubstepu.", 2.5f, 0, nieBedziemy);
				kermit.say("Dubstep był modny 15 lat temu", 3.2f, 1);
				kermit.say("Poza tym najchętniej bym", 1.1f, 2);
				kermit.ShutUp(3);
				if(kermit.ResetAction(4))
				{
					f=false;
					g=true;
				}
			}
			if(g)
			{
				kot.say("Puszczaj dapstep!", 1.2f, 0, puszczajDapstep);
				kot.say("Ja wale gdzie to sie puszcza ja to puszczę!", 2.3f, 1);
				if(kot.ResetAction(2))
				{
					g=false;
					h=true;
				}
			}
			if(h && !z)
			{
				Bloom bloomLayer = null;
 				ChromaticAberration chromaticAberration = null;
 				Grain grain = null;
 
 
 				PostProcessVolume volume = cam.GetComponent<PostProcessVolume>();
 				volume.profile.TryGetSettings(out bloomLayer);
 				volume.profile.TryGetSettings(out chromaticAberration);
 				volume.profile.TryGetSettings(out grain);

 
 				bloomLayer.enabled.value = true;
 				bloomLayer.intensity.value += Time.deltaTime * 24;
 
 				chromaticAberration.enabled.value = true;
				chromaticAberration.intensity.value = Random.Range(0.2f, 0.6f);

				grain.intensity.value = Random.Range(0.4f, 0.9f);
 				float w;
				mixer.GetFloat("Rate", out w);
				mixer.SetFloat("Rate", w + Time.deltaTime * 2);

				mixer.GetFloat("RateMusic", out w);
				mixer.SetFloat("RateMusic", w + Time.deltaTime * 1.6f);

				kermit.say("Zostaw to!", 1.3f, 0, zostawTo);
				kermit.say("Nie masz pojęcia co robisz!", 1.3f, 1);
				kermit.say("Nie!!!!", 3.0f, 2);
				if(kermit.ResetAction(3))
				{
					mixer.SetFloat("Rate", w * 0);
					mixer.SetFloat("RateMusic", w * 0);
                    GameJolt.API.Trophies.Unlock(103686, (bool success) => {
                        if (success)
                        {
                            Debug.Log("Success!");
                        }
                        else
                        {
                            Debug.Log("Something went wrong");
                        }
                    });
                    sceneManager.GetComponent<SceneManager>().changeScene(nextScene);
                    z = true;

				}
			}
			
		}
	}
    bool z;
    public string nextScene;
}
