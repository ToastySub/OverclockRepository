using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("on");
			if (Input.GetKeyDown (KeyCode.T)) {
				Debug.Log ("t");	
				SceneManager.LoadScene ("Rest Area");
			}
		}
	}
}
