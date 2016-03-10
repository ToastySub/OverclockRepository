using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

	void Awake()
	{
		this.enabled = false;
	}
	void OnEnable() 
	{
		Application.Quit ();
	}
}