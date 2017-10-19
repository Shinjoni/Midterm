using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class PC : MonoBehaviour {
	public float speed;
	public float maxSpeed;
	public float jumpForce;

	public bool isGrounded;
	public bool isShooting;
	public bool hurt;
	public bool isAlive;

	private Rigidbody2D rigiBody;
	private Animator anim;

	public AudioClip jumpSfx;
	public AudioClip coinCollect;
	public AudioClip damageSfx;
	public AudioClip ebullet;

	public AudioSource audio;

	public GameObject respawn;

	private GameMaster gm;

	//health stats
	public int curHealth; //current health integer
	public int maxHealth = 3; //full health is 3
	public bool deathCheck; //checks if player is dead
	public bool isDamaged; //checks if player is damaged


	//projectile
	public Transform bulletPoint;
	public GameObject bullet;




	void Start () {

		rigiBody = gameObject.GetComponent<Rigidbody2D> (); //get give us access to Rigifbody2D component
		anim = gameObject.GetComponent<Animator>(); //get access to Animator component

		audio = GetComponent<AudioSource> (); // get access to Audio component

		gm = GameObject.FindGameObjectWithTag ("Game Master").GetComponent<GameMaster> (); // get access to Game Master script



	}


	void Update () {

		anim.SetBool ("is Grounded", isGrounded); //setting grounded value in animation
		anim.SetBool ("is Shooting" , isShooting); // setting shooting var
		anim.SetFloat ("Speed", Mathf.Abs(rigiBody.velocity.x)); // setting speed value in animation; Mathf.Abs allows us to use the absolute value of the variable
		anim.SetBool("isAlive", isAlive); //setting ISAlive animation parameter
		anim.SetBool("is Damaged", isDamaged); //setting IsDamaged animation parameter


		float h = Input.GetAxis ("Horizontal");


		if (Input.GetAxis ("Horizontal") < -.001f ) {

			transform.localScale = new Vector3 (-1.0f, 1.0f, 1.0f);

		}

		if (isGrounded) {

			rigiBody.AddForce ((Vector2.right * speed) * h); //moved player left and right


		}

		if (Input.GetAxis ("Horizontal") > .001f ) {

			transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

		}

		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {

			rigiBody.AddForce (Vector2.up * jumpForce); // adding force vertically to jump
			GetComponent<AudioSource>().PlayOneShot( jumpSfx, 1.0f); // plays jump sound

		}

		if (!isGrounded) {

			speed = 40f;

		}

		else {

			speed = 80f;

		}

		if (curHealth > maxHealth) {

			curHealth = maxHealth; // always sets health to max (3) at start of game

		}

		if (curHealth <= 0) {

			StartCoroutine ("DelayedRestart");

		}

		if (Input.GetKeyDown (KeyCode.Z)) {
						Instantiate (bullet, bulletPoint.position, bulletPoint.rotation);
				}
		if (isShooting == true) {
			speed = 100f;
		}

	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.CompareTag ("Kill Zone")) {

			transform.position = respawn.transform.position;
			curHealth -= 3;
		}

		if (col.CompareTag ("Coin")) {

			Destroy(col.gameObject);
			gm.points += 1;
			GetComponent<AudioSource>().PlayOneShot (coinCollect, 1.0f);


		}
			

	}

	void FixedUpdate () 

	{

		Vector3 easeVelocity = rigiBody.velocity;
		easeVelocity.y = rigiBody.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.0f;

		if (isGrounded || isShooting) 

		{

			rigiBody.velocity = easeVelocity;

		}

		//Limiting the speed of the character*
		if ( rigiBody.velocity.x > maxSpeed ) 

		{

			rigiBody.velocity = new Vector2 ( maxSpeed, 0f );

		}

		if ( rigiBody.velocity.x < -maxSpeed ) 

		{

			rigiBody.velocity = new Vector2 ( -maxSpeed, 0f );

		}

	}

	void Death () {

		deathCheck = true;
		Debug.Log ("Player is dead");
		//reload scene or respawn
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//SceneManager.LoadScene(SceneManger.getCctiveScene().buildIndex);

	}

	IEnumerator DelayedRestart () {

		yield return new WaitForSeconds (3); //delay by time
		Death();
		//SceneManager.LoadScene (restart);

	}


	public void Damage (int dmg) {


		GetComponent<AudioSource>().PlayOneShot (damageSfx, 1.0f); //play damage sound effect

		curHealth -= dmg; //take negative damage integer
		}

	}



