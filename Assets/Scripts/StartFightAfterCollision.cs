using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFightAfterCollision : MonoBehaviour {

	public SceneLoader SceneLoader;

	void OnTriggerEnter2D (Collider2D collision) {
        if(collision.gameObject.tag == "Player")
        {
            SceneLoader.StartFight(gameObject);
        }
	}
}
