using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClipAmmo : MonoBehaviour {
	[SerializeField] private Player player;
	[SerializeField] private Text ammoDisplay;
	[SerializeField] private GameObject pistol;
	[SerializeField] private GameObject blaster;
	[SerializeField] private GameObject launcher;
	private int currentClip;
	private int clipSize;
	// Use this for initialization
	void Start () {
		ammoDisplay = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (pistol.active == true) {
			currentClip = pistol.GetComponent<PistolScript> ().currentClip;
			clipSize = pistol.GetComponent<PistolScript> ().clipSize;
		}
		if (blaster.active == true) {
			currentClip = blaster.GetComponent<BlasterScript> ().currentClip;
			clipSize = blaster.GetComponent<BlasterScript> ().clipSize;
		}

		ammoDisplay.text = currentClip.ToString () + "/" + clipSize.ToString ();
	}
}
