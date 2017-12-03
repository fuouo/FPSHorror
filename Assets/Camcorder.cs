using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camcorder : MonoBehaviour {

	public GameObject camCorder;
	public Image batteryLife;
	public Text Record;

	// Use this for initialization
	void Start () {
		StartCoroutine (startCamera ());
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			GetComponent<Camera> ().fieldOfView--;
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0)
			GetComponent<Camera> ().fieldOfView++;
	}

	IEnumerator startCamera(){
		StartCoroutine (startBattery ());
		StartCoroutine (blinkRecord ());

		yield return null;
	}

	IEnumerator blinkRecord(){
		Record.enabled = !Record.enabled;
		yield return new WaitForSeconds (0.5f);
		StartCoroutine (blinkRecord ());
	}

	IEnumerator startBattery(){
		if (batteryLife.fillAmount <= 0.5f) {
			camCorder.GetComponent<Animator> ().SetBool ("isDead", true);
			yield return new WaitForSeconds (1f);
			yield return new WaitForEndOfFrame();
			camCorder.GetComponent<Animator> ().SetBool ("isDead", false);
			camCorder.gameObject.SetActive (false);


		} else {
			Debug.Log (batteryLife.fillAmount);
			yield return new WaitForSeconds (1.0f);
			batteryLife.fillAmount -= 0.10f;
			StartCoroutine (startBattery ());
		}
	}
}
