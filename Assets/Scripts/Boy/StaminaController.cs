using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour {

	[Header("Panel")]
	[SerializeField] private GameObject bgBlackPanel;
	[SerializeField] private GameObject gameOverPanel;

	[Header("Distance Panel Controller")]
	[SerializeField] private Text distanceTxt;

	[Header("Stamina Bar")]
	[SerializeField] private Stamina stamina;
	[SerializeField] private float maxStaminaValue;
	[SerializeField] private float custStaminaValue;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		bgBlackPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		stamina.Initialize(maxStaminaValue, maxStaminaValue);
	}
	
	// Update is called once per frame
	void Update () {
		if(stamina.CurrentValue == 0){
			distanceTxt.text = BoyMovement.distanceTotal.ToString();
			bgBlackPanel.SetActive(true);
			gameOverPanel.SetActive(true);
			player.SetActive(false);
		}

		stamina.CurrentValue -= custStaminaValue * Time.deltaTime;
	}

	public void StaminaBonus(float bonusValue){
		stamina.CurrentValue += bonusValue;
	}
}
