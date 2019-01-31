using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem : MonoBehaviour {
	public int _amountToPool;
	public GameObject _objectToPool;
	public bool _willGrow;
}
