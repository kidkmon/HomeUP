using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundCollider : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if(!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("Pillow")){
			collider.gameObject.SetActive(false);
		}
	}
}
