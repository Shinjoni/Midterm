using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	private PC player; //name of the player controller script

	public int points;

	public Text soulsText;

	// Update is called once per frame
	void Update () {
		
	soulsText.text = ("Souls: 0" + points);

	}
}
