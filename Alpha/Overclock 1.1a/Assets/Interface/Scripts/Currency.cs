using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {
	private Text coins;
	public Player player;

	void Start () {
		coins = this.GetComponent<Text>();
		player.GetComponent<Player>();
	}
	void Update() {
		coins.text = player.PlayerStats.gold.ToString ();
	}

}
