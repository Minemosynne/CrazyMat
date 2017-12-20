using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawner : MonoBehaviour {

    private LootDropItem.Type Type;
    public ItemSpawnTable ItemSpawnTable;

	// Nombre max d'items sur la carte
    public int MaxItems;
	// Nombre d'items spawnés sur la carte
    private int nbItemsSpawned = 0;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public float MinSpawnDistance;

    public LayerMask LayerMaskItem;
	public LayerMask LayerMaskHero;
	public LayerMask LayerMaskEnemy;

    void OnEnable() {
        ItemSpawnTable.LoadTable();
        Debug.Log("-----------Table--------------");
        StartCoroutine(SpawnCoroutine());
    }

    void OnDisable() {
        StopAllCoroutines();
    }

	// Spawn un item sur la carte
    void SpawnItem() {
        Vector3 position = GetNewPosition();

		// Vérification dans un rayon de 'minSpawnDistance' qu'il n'y a pas déjà un autre item, un ennemi ou le héros
		if (!Physics2D.OverlapCircle(position, MinSpawnDistance, LayerMaskItem) 
			&& !Physics2D.OverlapCircle(position,MinSpawnDistance,LayerMaskHero)
			&& !Physics2D.OverlapCircle(position,MinSpawnDistance,LayerMaskEnemy)) {

			// Récupère l'item à spawner
            GameObject item = ItemSpawnTable.PickDroppedItem();
            Instantiate(item);
            Debug.Log("------>Item : " + item.GetComponent<Item>().SpawnedItem.ItemType);
            item.transform.position = position;
            item.transform.rotation = transform.rotation;

            nbItemsSpawned++;
        }
    }

	// Récupère la position aléatoire où l'item sera spawné
    Vector3 GetNewPosition() {
        Vector3 tmp = transform.position;
        tmp.x = UnityEngine.Random.Range(MinX, MaxX);
        tmp.y = UnityEngine.Random.Range(MinY, MaxY);
        return tmp;
    }

	// Coroutine de spawn des items
    IEnumerator SpawnCoroutine() {
        while (nbItemsSpawned < MaxItems) {
            SpawnItem();
			// Spawn de tous les items à la fois
            yield return new WaitForSeconds(0f);
        }
    }
}
