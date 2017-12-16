using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToPickUp : MonoBehaviour
{

    /*public enum Type {
		POTION, SCRAP, GEAR, METAL
	}

	public static int maxObjects = 50;
	public int nbObjectsSpawned = 0;

	public float minY;
	public float maxY;
	public float minSpawnDistance = 2f;

	public Poolable objectPrefab;

	void OnEnable() {
		StartCoroutine (SpawnCoroutine ());
	}

	void OnDisable() {
		StopAllCoroutines ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnObject() {
		Vector3 position;
		position = GetNewPosition ();
		GameObject obj = objectPrefab.GetInstance ();
		obj.transform.position = position;
		nbObjectsSpawned++;
	}

	Vector3 GetNewPosition() {
		Vector3 tmp = transform.position;
		tmp.y = Random.Range (minY, maxY);
		return tmp;
	}

	IEnumerator SpawnCoroutine() {
		while (nbObjectsSpawned < maxObjects) {
			SpawnObject ();
			yield return new WaitForSeconds (0.1f);
		}
	}*/

}
