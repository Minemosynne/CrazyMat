using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/Enemy Spawn Table", fileName = "EnemySpawnTable")]
public class EnemySpawnTable : ScriptableObject {

	protected const int maxProbability = 10;

    // SMALL 0-3, BIG 4-6, SMALL_BOSS 7-8, BIG_BOSS 9-10
	protected int[] lootProbabilities = new int[] {
        3,6,8, maxProbability
	};

    public static Poolable smallEnemyPrefab;
    public static Poolable bigEnemyPrefab;
    public static Poolable smallBossEnemyPrefab;
    public static Poolable bigBossEnemyPrefab;

	// Tableau des prefabs des ennemis
    public Poolable[] enemyPrefabs = new Poolable[] {
        smallEnemyPrefab, bigEnemyPrefab,
        smallBossEnemyPrefab, bigBossEnemyPrefab
    };

	// Choisit aléatoirement le type de l'ennemi en fonction des probabilités
    public Enemy.Type Choose() {
		Enemy.Type typeEnemy = 0;
		int randValue = Random.Range (0, maxProbability);
		while (lootProbabilities [(int)typeEnemy] <= randValue) {
			typeEnemy++;
		}
		return typeEnemy;
	}
}
