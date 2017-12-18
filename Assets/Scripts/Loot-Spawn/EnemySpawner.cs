using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{

    private Enemy.Type typeEnemy;
    public EnemySpawnTable lootEnemy;

    public static int maxEnemies = 25;
    private int nbEnemiesSpawned = 0;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minSpawnDistance;

    public LayerMask layerMask;

    void OnEnable()
    {
        StartCoroutine(SpawnCoroutine());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void SpawnEnemy()
    {
        //TODO pas dans la case de départ
        Vector2 position = GetNewPosition();

        if (!Physics2D.OverlapCircle(position, minSpawnDistance, layerMask))
        {
            this.typeEnemy = lootEnemy.Choose();

            GameObject obj = lootEnemy.enemyPrefabs[(int)this.typeEnemy].GetInstance();
            obj.transform.position = position;
            obj.transform.rotation = transform.rotation;

            nbEnemiesSpawned++;
            Debug.Log("--Enemy type : " + this.typeEnemy);
            Debug.Log(nbEnemiesSpawned + " enemies spawned !");
        }
    }

    Vector3 GetNewPosition()
    {
        Vector3 tmp = transform.position;
        tmp.x = UnityEngine.Random.Range(minX, maxX);
        tmp.y = UnityEngine.Random.Range(minY, maxY);
        return tmp;
    }

    IEnumerator SpawnCoroutine()
    {
        while (nbEnemiesSpawned < maxEnemies)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0f);
        }
    }
}
