using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawm : MonoBehaviour {

	private int cont = 0;
	private float timeCheck;

	// Update is called once per frame
	void Update () {
		timeCheck += Time.deltaTime*2;
		UpdatePositionWalls();
	}

	void UpdatePositionWalls(){
		int randomNumber = Random.Range(1,8);

		GameObject obj = ObjectPooler._current.GetPooledObjects("Wall"+randomNumber.ToString()+"(Clone)");
		
		if(obj == null) return;
		if(timeCheck > 10){
			obj.gameObject.transform.GetChild(4).gameObject.SetActive(true);			
			timeCheck = 0;
		}
		
		obj.transform.position = Vector3.up * 1.16f * cont;
		
        obj.SetActive(true);
		cont += 1;
	}
}
