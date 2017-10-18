using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

	public Sprite fullHearts;
	public Sprite twoHearts;
	public Sprite oneHearts;
	public Sprite emptylHearts; 

	public Image heartUI;

	private PlayerControl player;




	// Use this for initializations
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();

	}
	
	// Update is called once per frame
	void Update () {

		if(player.curHealth  == 3){

			heartUI.sprite = fullHearts;

		}
		if(player.curHealth  == 2){

			heartUI.sprite = twoHearts;

		}
		if(player.curHealth  == 1){

			heartUI.sprite = oneHearts;

		}
		if(player.curHealth  == 0){

			heartUI.sprite = emptylHearts;

		}
	}
}