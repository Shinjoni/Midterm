using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public LayerMask enemyMask;
	public float speed = 1f;
	Rigidbody2D myBody;
	Transform myPosition;
	float myWidth, myHeight;


	// Use this for initialization
	void Start () {
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer> ();

		myPosition = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}

	void FixedUpdate (){
		Vector2 lineCastPos = myPosition.position.toVector2() - myPosition.right.toVector2() * myWidth + Vector2.up * 1f;
		Debug.DrawLine (lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down, enemyMask);
		Debug.DrawLine (lineCastPos, lineCastPos - myPosition.right.toVector2() * .05f);
		bool isBlocked = Physics2D.Linecast (lineCastPos, lineCastPos - myPosition.right.toVector2() * .05f, enemyMask);

		if (!isGrounded || isBlocked)
			{
				Vector3 currRot = myPosition.eulerAngles;
				currRot.y += 180;
				myPosition.eulerAngles = currRot;
	}
	// Update is called once per frame
				Vector2 myVelocity = myBody.velocity; 
			myVelocity.x = myPosition.right.x * -speed;
		myBody.velocity = myVelocity;
}
}
