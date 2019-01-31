using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Follow : MonoBehaviour {

	[Header("Panel")]
	public GameObject gameOverPanel;
	public GameObject bgBlackPanel;

	[Header("Distance Panel")]
	public Text distanceTxt;

	[Header("Follow Player Controller")]
	[SerializeField] private float distanceFromPlayer;

	private GameObject player;
	private float currentPlayerPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		gameOverPanel.SetActive(false);
		bgBlackPanel.SetActive(false);
		currentPlayerPosition = player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(currentPlayerPosition < player.transform.position.y){
			currentPlayerPosition = player.transform.position.y;
			transform.position = new Vector3(0, currentPlayerPosition-distanceFromPlayer,0);
		}

		if(transform.position.y >= player.transform.position.y){
			//Game Over
			player.SetActive(false);
			distanceTxt.text = BoyMovement.distanceTotal.ToString();
			bgBlackPanel.SetActive(true);
			gameOverPanel.SetActive(true);
		}
	}
}
