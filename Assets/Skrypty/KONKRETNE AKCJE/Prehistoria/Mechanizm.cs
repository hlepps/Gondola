using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanizm : MonoBehaviour {

    int number;
    bool action;
    public float distance;
    public GameObject global, gondola, eq, mouseFollow;
    public GameObject patykM, koloM, kamien, kamienAnim, sceneManager;
    public string scenename;

    void Update()
    {
        if (action)
        {
            if (number == 0)
            {
                if(mouseFollow.GetComponent<Mouse>().attachedID == 11)
                {
                    number++;
                    eq.GetComponent<EQ>().delItem(11);
                    patykM.SetActive(true);
                    action = false;
                }

            }
            else if (number == 1)
            {
                if (mouseFollow.GetComponent<Mouse>().attachedID == 10)
                {
                    number++;
                    eq.GetComponent<EQ>().delItem(10);
                    koloM.SetActive(true);
                    action = false;
                }
            }
            else if (number == 2)
            {
                kamien.SetActive(false);
                kamienAnim.SetActive(true);
                action = false;
                number++;
                sceneManager.GetComponent<SceneManager>().changeScene(scenename);
            }
        }
        action = false;
    }

    private void OnMouseDown()
    {

        action = true;


    }
}
