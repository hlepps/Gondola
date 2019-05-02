using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolusion : MonoBehaviour {

    //Resolusion[] resolutions;
    Resolution[] resolutions;

    public Dropdown dropdown;

	// Use this for initialization
	void Start () {
        resolutions = Screen.resolutions;

        dropdown.ClearOptions();

        int currRes = 0;

        List<string> options = new List<string>();

        for(int i = 0; i < resolutions.Length; i++)
        {
            string res = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(res);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currRes = i;
            }
        }

        dropdown.AddOptions(options);
        dropdown.value = currRes;
        dropdown.RefreshShownValue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetResolution (int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
