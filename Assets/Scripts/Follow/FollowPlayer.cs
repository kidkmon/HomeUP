using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Transform playerPosition;
	private float currentPlayerPosition;

	// Use this for initialization
	void Start () {
		playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
		currentPlayerPosition = playerPosition.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentPlayerPosition < playerPosition.position.y){
			currentPlayerPosition = playerPosition.position.y;
			transform.position = playerPosition.position;
		}
	}
}
