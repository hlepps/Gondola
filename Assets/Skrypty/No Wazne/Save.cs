using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 

public class Save : MonoBehaviour{

	public GameObject EQ, sceneManager, global, clickAudio, btaudio;
    public Color normalColor, najechanedColor;
    public Sprite clicked, normal;

	public static List<Game> savedGames = new List<Game>();

	public bool wczytaj;

	void OnMouseDown()
	{
        clickAudio.GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().sprite = clicked;
        if (wczytaj)
		{
			LoadGame();
		}
		else
		{
			SaveGame();
		}
	}

    private void OnMouseEnter()
    {

        btaudio.GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().color = najechanedColor;

    }

    private void OnMouseExit()
    {

        GetComponent<SpriteRenderer>().color = normalColor;
    }


    [System.Serializable]
	public struct Game
	{
		public string sceneName;

		public bool[] gbValue;
		public string[] gbName;

		public int[] eq;

		
		
		

	}

	static int gbools;
	Game game;

	void Start()
	{
		sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
		global = GameObject.FindGameObjectWithTag("Global");

		gbools = global.GetComponent<Global>().gonbools;

		game.sceneName = "";
		game.gbValue = new bool[gbools];
		game.gbName = new string[gbools];
		game.eq = new int[12];
		
	}



    //it's static so we can call it from anywhere
    public void SaveGame() {


		game.sceneName = sceneManager.GetComponent<SceneManager>().GetActualScene();
		for(int i = 0; i < global.GetComponent<Global>().gonbools; i++)
		{
			game.gbName[i] = global.GetComponent<Global>().getGonboolName(i);
			game.gbValue[i] = global.GetComponent<Global>().getGonbool(i);
		}

		for(int i = 0; i < 12; i++)
		{
			game.eq[i] = EQ.GetComponent<EQSave>().getItem(i);
		}

		
		

        
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(Application.persistentDataPath);
        FileStream file = File.Create (Application.persistentDataPath + "/savedGames.sauce"); //you can call it anything you want
        bf.Serialize(file, game);
        file.Close();
    }   
     
    public void LoadGame() {
        Debug.Log("1");
        if(File.Exists(Application.persistentDataPath + "/savedGames.sauce")) {
            Debug.Log("2, " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.sauce", FileMode.Open);
            game = (Game)bf.Deserialize(file);
            file.Close();

			Debug.Log(game.gbName[9990-3]);    //////////////
			for(int i = 0; i < gbools; i++)
			{
				global.GetComponent<Global>().SetGonboolName(i, game.gbName[i]);
				global.GetComponent<Global>().setGonbool(game.gbName[i], game.gbValue[i]);
			}
			for(int i = 0; i < 12; i++)
			{
				EQ.GetComponent<EQSave>().setItem(i, game.eq[i]);
			}
			Debug.Log(game.sceneName);
            Debug.Log("3");

            Application.LoadLevel(game.sceneName);

        }
    }
}

