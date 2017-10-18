using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	private PlayerControl player;

	public int points;

	public Text pointsText;

	
	// Update is called once per frame
	void Update () {

		pointsText.text = ("points: " + points);

	}
}
