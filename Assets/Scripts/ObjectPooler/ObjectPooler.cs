using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public static ObjectPooler _current;
	public List<ObjectPoolItem> itemsToPool;

	List<GameObject> __pooledObjects;

	void Awake(){
		_current = this;
	}

	void Start () {
		__pooledObjects = new List<GameObject>();
		foreach(ObjectPoolItem item in itemsToPool){
			for(int i = 0; i < item._amountToPool; i++){
				GameObject obj = (GameObject) Instantiate(item._objectToPool);
				obj.SetActive(false);
				__pooledObjects.Add(obj);
			}
		}
	}
	
	public GameObject GetPooledObjects(string name){
		for(int i = 0; i < __pooledObjects.Count; i++){
			if(!__pooledObjects[i].activeInHierarchy && __pooledObjects[i].name == name){
				return __pooledObjects[i];
			}
		}

		foreach(ObjectPoolItem item in itemsToPool){
			if(item._objectToPool.name == name){
				if(item._willGrow){
					GameObject obj = (GameObject) Instantiate(item._objectToPool);
					obj.SetActive(true);
					__pooledObjects.Add(obj);
					return obj;
				}
			}
		}

		return null;
	}
}
