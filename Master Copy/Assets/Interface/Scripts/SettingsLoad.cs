using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;		
public class SettingsLoad : MonoBehaviour {

	void Awake()
	{
		this.enabled = false;
	}
	void OnEnable() 
	{
		SceneManager.LoadScene("Settings");
	}
}