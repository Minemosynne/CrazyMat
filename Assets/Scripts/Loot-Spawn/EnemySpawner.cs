using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour {
	
    private Enemy.Type typeEnemy;
    public EnemySpawnTable lootEnemy;

	// Nombre max d'ennemis sur la carte
    public int maxEnemies;
	// Nombre d'ennemis spawnés sur la carte
    private int nbEnemiesSpawned = 0;
    //Pour instantier les ennemis en enfants de la bigMap
    private Transform bigMap;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minSpawnDistance;

    public LayerMask layerMaskEnemy;
	public LayerMask layerMaskHero;
	public LayerMask layerMaskItem;

    void OnEnable() {
        bigMap = GameObject.FindGameObjectWithTag("Map").transform;
        StartCoroutine(SpawnCoroutine());
    }

    void OnDisable() {
        StopAllCoroutines();
    }

	// Spawn un ennemi sur la carte
    void SpawnEnemy() {
        Vector3 position = GetNewPosition();

		// Vérification dans un rayon de 'minSpawnDistance' qu'il n'y a pas déjà un autre ennemi, un item ou le héros
		if (!Physics2D.OverlapCircle(position, minSpawnDistance, layerMaskEnemy)
			&& !Physics2D.OverlapCircle(position, minSpawnDistance, layerMaskHero)
			&& !Physics2D.OverlapCircle(position, minSpawnDistance, layerMaskItem)) {
			// Choisit le type d'ennemi à spawner
            this.typeEnemy = lootEnemy.Choose();

            // Récupère l'ennemi à spawner
            GameObject obj = lootEnemy.enemyPrefabs[(int)this.typeEnemy].GetInstance();
            obj.transform.position = position;
            obj.transform.rotation = transform.rotation;

            nbEnemiesSpawned++;
            Debug.Log("--Enemy type : " + this.typeEnemy);
            Debug.Log(nbEnemiesSpawned + " enemies spawned !");
        }
    }

	// Récupère la position aléatoire où l'ennemi sera spawné
    Vector3 GetNewPosition() {
        Vector3 tmp = transform.position;
        tmp.x = UnityEngine.Random.Range(minX, maxX);
        tmp.y = UnityEngine.Random.Range(minY, maxY);
        return tmp;
    }

	// Coroutine de spwan des ennemis
	IEnumerator SpawnCoroutine() {
        while (nbEnemiesSpawned < maxEnemies) {	
            SpawnEnemy();
			// Spawn de tous les ennemis à la fois
            yield return new WaitForSeconds(0f);
        }
    }
}
