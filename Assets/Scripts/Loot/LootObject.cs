using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootObject : MonoBehaviour {

	public enum TypeObject {
		POTION, GEAR, METAIL, SCRAP 
	}

	protected const int maxProbability = 12;

	protected int[] lootProbabilities = new int[] {
		1, 4, 7, maxProbability
	};

	public TypeObject Choose() {
		TypeObject typeObject = 0;
		int randValue = Random.Range (0, maxProbability);
		while (lootProbabilities [(int)typeObject] <= randValue) {
			typeObject++;
		}
		return typeObject;
	}

}
