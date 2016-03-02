using UnityEngine;
using System.Collections;

public class gameMaster : MonoBehaviour {

	float overclockMax = 100f;
	float overclockCur = 100f;
	public bool overclock = false;

	//public static void killPlayer (Player player){
	//	killPlayer (player);
//	}

		void Start(){
		InvokeRepeating ("TimeMechanic", 5, 5);
		}
		


		void TimeMechanic ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift) && overclockCur > 0) {
			if (overclock) {
				if (overclockCur > 0) {
					overclockCur -= 5;
					Time.timeScale = 0.7f;
				}
			} else {
				if (overclockCur < overclockMax) {
					overclockCur = +1;
					overclock = false;
					Time.timeScale = 1.0f;
				}
			}
		}
	}

}