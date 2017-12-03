using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public Animator animator;
	public bool isWalking = true;
	public bool isHit = false;
	public Quaternion startingRotation;
	public float rotationSpeed;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		isWalking = true;

		animator.SetBool ("isWalking", isWalking);
		startingRotation = this.transform.rotation;
		StartCoroutine (walk());
	}
	
	// Update is called once per frame
	void Update () {
		if (isWalking && !isHit)
			Move ();
		
	}

	IEnumerator walk(){
		if (isHit)
			yield return null;

		yield return new WaitForSeconds (5.0f);
		isWalking = !isWalking;
		animator.SetBool ("isWalking", isWalking);
		startingRotation = this.transform.rotation;
		StartCoroutine (Rotate (-90)); //rotate during idle time
		StartCoroutine (walk());

	}

	IEnumerator Rotate(float rotationAmount){
		Quaternion finalRotation = Quaternion.Euler( 0, rotationAmount, 0 ) * startingRotation;

		while(this.transform.rotation != finalRotation){
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, finalRotation, Time.deltaTime*rotationSpeed);
			yield return 0;
		}
	}
		
	void Move(){
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
	}



}
