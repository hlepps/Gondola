using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;

public class Login : MonoBehaviour {

	public void goLogin()
	{
		GameJoltUI.Instance.ShowSignIn();
	}
}
