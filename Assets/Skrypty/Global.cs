using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    public bool paused = false;
    public bool waiting = false;

    public int gonbools = 10000;

    public static bool inited;
    

    public struct Gonbool
    {
        public bool value;
        public string name;

        public Gonbool(bool v, string n)
        {
            value = v;
            name = n;

        }
    };
    public static Gonbool[] gb = new Gonbool[10000];
    
    void initgonbools()
    {
        if (!inited)
        {
            for (int i = 0; i < gonbools; i++)
            {
                gb[i] = new Gonbool(false, "");
            }
            inited = true;
        }
    }

    


    public void newGonbool(int numer, string name, bool value)
    {
        if (gb[numer].name == gb[0].name)
        {
            gb[numer] = new Gonbool(value, name);
        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);



    }

    private void Start()
    {
        Debug.Log(inited);
        if (!inited)
        {
            initgonbools();
            newGonbool(1, "poducha", false);
            newGonbool(2, "umyjzeby", false);
            newGonbool(3, "umytezeby", false);
            newGonbool(4, "oknozbite", false);
            newGonbool(5, "oknoJUZzbite", false);
            newGonbool(6, "animacjaStartGry", false);
            newGonbool(7, "odKam", false);
            newGonbool(8, "zapukanoKermit", false);
            newGonbool(9, "klikKot", false);
            newGonbool(10, "ahusPrzeddom", false);
            newGonbool(11, "startPrzeddom", false);
            newGonbool(12, "uratowanoKota", false);
            newGonbool(13, "wchodziKermit", false);

            

            Debug.Log("Inited all");
        }
    }



    public void setGonbool(string n, bool v)
    {
        for(int i = 0; i < gonbools; i++)
        {
            if(gb[i].name == n)
            {
                gb[i].value = v;
                //Debug.Log("set " + i + " as " + gb[i].value);
                break;
            }
        }
    }


    public void setGonbool(int id, bool v)
    {
        
        gb[id].value = v;
        
    }

    public bool getGonbool(string n)
    {
        for (int i = 0; i < gonbools; i++)
        {
            if (gb[i].name == n)
            {
                //Debug.Log("returning " + gb[i].value + " for " + n);
                return gb[i].value;
                
            }
            
        }
        Debug.Log("Theres no gonbool like " + n);
        return false;
    }

    public bool getGonbool(int n)
    {
        return gb[n].value;
    }

    public string getGonboolName(int n)
    {
        return gb[n].name;
    }

    public void SetGonboolName(int number, string newName)
    {
        gb[number].name = newName;
    }

}
