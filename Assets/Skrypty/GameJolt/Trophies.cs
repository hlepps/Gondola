using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;

public class Trophies : MonoBehaviour {

	public void GoTrophies()
	{
		GameJoltUI.Instance.ShowTrophies();
	}
}
