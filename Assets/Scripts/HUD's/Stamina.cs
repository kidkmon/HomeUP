using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

	public float MaxValue{ get; set;}
	
	public float CurrentValue{
		get{
			return currentValue;
		}
		set{
			currentValue = (value > MaxValue) ? MaxValue : (value < 0) ? 0 : value;
			currentFill = currentValue / MaxValue;
		}
	}

	[SerializeField] private float lerpSpeed;

	private Image barContent;

	private float currentFill;
	private float currentValue;

	// Use this for initialization
	void Start () {
		barContent = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentFill < barContent.fillAmount){
			barContent.fillAmount = Mathf.Lerp(barContent.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
		}
		else{
			barContent.fillAmount = currentFill;
		}
	}

	public void Initialize(float currentValue, float maxValue){
		MaxValue = maxValue;
		CurrentValue = currentValue;
	}
}
