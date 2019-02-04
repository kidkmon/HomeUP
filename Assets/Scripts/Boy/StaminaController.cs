using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour {

	[Header("Stamina Animator")]
	[SerializeField] private Animator staminaAnimator;

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

		StaminaAnimationState();

		stamina.CurrentValue -= custStaminaValue * Time.deltaTime;
	}

	public void StaminaBonus(float bonusValue){
		stamina.CurrentValue += bonusValue;
	}

	void StaminaAnimationState(){
		if(stamina.CurrentValue > 80.0f){
			staminaAnimator.SetBool("Up", true);
			staminaAnimator.SetBool("Idle", false);
			staminaAnimator.SetBool("Down", false);
		}
		else if(stamina.CurrentValue < 30.0f){
			staminaAnimator.SetBool("Down", true);
			staminaAnimator.SetBool("Idle", false);
			staminaAnimator.SetBool("Up", false);
		}
		else{
			staminaAnimator.SetBool("Idle", true);
			staminaAnimator.SetBool("Up", false);
			staminaAnimator.SetBool("Down", false);
		}
	}
}
