using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour {

    public AudioMixer mixer;
    public string channel;
    

    public float value;


    private void OnEnable()
    {
        mixer.GetFloat(channel, out value);
        GetComponent<Slider>().value = value;
    }

    public void setValue(float v)
    {
        value = v;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mixer.SetFloat(channel, value);
	}
}
