using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFightAfterCollision : MonoBehaviour {

	public SceneLoader SceneLoader;

	void OnTriggerEnter2D (Collider2D col) {
        SceneLoader.StartFight(gameObject);
	}
}
