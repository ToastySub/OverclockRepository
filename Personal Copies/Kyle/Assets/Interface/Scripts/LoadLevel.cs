using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;		

public class LoadLevel : MonoBehaviour 
{
	void Awake()
	{
		this.enabled = false;
	}

	public void OnEnable() 
	{
		SceneManager.LoadScene("Level1");
	}
}