using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootEnemy : MonoBehaviour {

	public enum TypeEnemy {
		SMALL_BOSS, BIG_BOSS, SMALL, BIG
	}

	protected const int maxProbability = 8;

	protected int[] lootProbabilities = new int[] {
		1, 2, 5, maxProbability
	};

	public TypeEnemy Choose() {
		TypeEnemy typeEnemy = 0;
		int randValue = Random.Range (0, maxProbability);
		while (lootProbabilities [(int)typeEnemy] <= randValue) {
			typeEnemy++;
		}
		return typeEnemy;
	}
}
