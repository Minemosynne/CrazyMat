using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFightAfterCollision : MonoBehaviour {

	public LayerMask layerMask;

	public GameObject enemy;

	public SceneLoader sceneLoader;

	void OnTriggerEnter2D (Collider2D col) {
		if (layerMask == (layerMask | (1 << col.gameObject.layer))) {
			sceneLoader.StartFight (enemy);
		}
	}
}
