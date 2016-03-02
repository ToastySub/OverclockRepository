using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;		
public class TitleLoad : MonoBehaviour {

	void Awake()
	{
		this.enabled = false;
	}
	void OnEnable() 
	{
		SceneManager.LoadScene("Title Screen");
	}
}