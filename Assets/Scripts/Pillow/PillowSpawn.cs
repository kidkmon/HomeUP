using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowSpawn : MonoBehaviour {

	public Transform[] pillows;

	private int randomNumber;

	// Use this for initialization
	void Start () {
		randomNumber = Random.Range(0, pillows.Length);
		Instantiate(pillows[randomNumber]);
	}
	
}
