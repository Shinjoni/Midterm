using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class PlayerControl : MonoBehaviour {

	public float speed;
	public float maxSpeed;
	public float jumpForce;

	public bool isGrounded;


	private Rigidbody2D rigiBody;
	private Animator anim;

	public AudioClip jumpSfx;
	public AudioClip coinCollect;
	public AudioClip damageSfx;

	AudioSource audio;

	public GameObject respawn;

	private GameMaster gm;

	//health stats
	public int curHealth;
	public int maxHealth =3;
	public bool deathCheck;
	public bool hurt;


	//Projectile
	public Transform bulltPoint;
	public GameObject bullet;


	// Use this for initialization
	void Start () {

		rigiBody = gameObject.GetComponent<Rigidbody2D> (); // gives accesss to Ritgidbody2D component
		anim = gameObject.GetComponent<Animator>(); //get access to Animator component

		audio = GetComponent<AudioSource>(); //get acces to Audio component

		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> (); //get access to Game Master script

	}

	// Update is called once per frame
	void Update () {

		anim.SetBool("IsGrounded", isGrounded); //setting gounded vale in animation
		anim.SetFloat ("Speed", Mathf.Abs(rigiBody.velocity.x)); //setting speed value in animation;
		anim.SetBool("IsAlive", deathCheck); //setting IsAlive animation parameter
		anim.SetBool("IsDamaged", hurt); //setting isDamaged Animation parameter


		float h = Input.GetAxis ("Horizontal");

		if (Input.GetAxis ("Horizontal") <-.001f) {

			transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);

		}

		if (isGrounded) {

			rigiBody.AddForce ((Vector2.right * speed) * h) ; //allows player to mvoe left and right

		}

		if (!isGrounded) {

			rigiBody.AddForce (((Vector2.right * speed) * h)/4) ; //allows player to mvoe left and right

		}

		if (Input.GetAxis ("Horizontal") >.001f) {

			transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

		}

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {

			rigiBody.AddForce (Vector2.up * jumpForce); //adding force vertically to jump
			audio.PlayOneShot( jumpSfx, 1.0f); //play jump sound

		}

		if (!isGrounded) {

			speed = 55f;

		}

		else {

			speed = 50f;

		}

		if (curHealth > maxHealth) {

			curHealth = maxHealth;

		}

		if (curHealth <= 0) {

			StartCoroutine ("DelayedRestart");

		}

		if(Input.GetKeyDown (KeyCode.Z)){
			Instantiate (bullet, bulltPoint.position, bulltPoint.rotation);
		}

	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag ("killzone")) {

			transform.position = respawn.transform.position;

		}

		if (col.CompareTag ("Coin")) {

			Destroy (col.gameObject);
			gm.points += 1;
			audio.PlayOneShot (coinCollect, 1.0f);

		}

		if (col.CompareTag("Coin5")) {

			Destroy(col.gameObject);
			gm.points += 5;
			audio.PlayOneShot(coinCollect, 1.0f);

		}

		if (col.CompareTag ("Level2")){

			SceneManager.LoadScene ("Level2");

			Debug.Log ("SCENE CHANGED");

		}

	}

	void FixedUpdata(){

		Vector3 easeVelocity = rigiBody.velocity;
		easeVelocity.y = rigiBody.velocity.y;
		easeVelocity.z = 0.05f;
		easeVelocity.x *= 0.05f;

		if (isGrounded) {

			rigiBody.velocity = easeVelocity;

		}

		if (rigiBody.velocity.x > maxSpeed) {

			rigiBody.velocity = new Vector2 (maxSpeed, 0f);

		}

		if (rigiBody.velocity.x < -maxSpeed) {

			rigiBody.velocity = new Vector2 (-maxSpeed, 0f);

		}

	}

	void Death (){

		deathCheck = true;
		Debug.Log ("Player is dead");
		//reolad scene or respawn
		SceneManager.LoadScene("level 1");

	}

	IEnumerator DelayedRestart(){

		yield return new WaitForSeconds (1);
		Death ();

	}

	public void Damage (int dmg){

		audio.PlayOneShot (damageSfx, 1.0f);
		curHealth -= dmg;

	}
}
