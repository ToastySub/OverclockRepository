using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour 
{
	public GameObject player;
	public Image HPFill;

	void Start () {
		
	}

	void Update () 
	{
		HPFill.fillAmount = 50; //player.GetComponent<Player> ().PlayerStats.currentHealth / player.GetComponent<Player>().PlayerStats.maxHealth;
	}
}
