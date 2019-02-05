using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePowerUp : MonoBehaviour {

	private Animator powerUpAnim;
	private int randomNum;

	// Use this for initialization
	void Awake () {
		powerUpAnim = GetComponent<Animator>();
	}

	void OnEnable(){
		randomNum = Random.Range(1,6);
		powerUpAnim.SetInteger("PowerUp", randomNum);
	}
	
}
