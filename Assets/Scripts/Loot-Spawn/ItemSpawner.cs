using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawner : MonoBehaviour {

    private LootDropItem.Type Type;
    public ItemSpawnTable ItemSpawnTable;

    public int MaxItems;
    private int _nbItemsSpawned = 0;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    public float MinSpawnDistance;

    public LayerMask LayerMaskItem;
	public LayerMask LayerMaskHero;

    void OnEnable()
    {
        ItemSpawnTable.LoadTable();
        Debug.Log("-----------Table--------------");
        StartCoroutine(SpawnCoroutine());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void SpawnItem()
    {
        Vector3 position = GetNewPosition();

		if (!Physics2D.OverlapCircle(position, MinSpawnDistance, LayerMaskItem) && !Physics2D.OverlapCircle(position,MinSpawnDistance,LayerMaskHero))
        {

            GameObject item = ItemSpawnTable.PickDroppedItem();
            Instantiate(item);
            Debug.Log("------>Item : " + item.GetComponent<Item>().SpawnedItem.ItemType);
            item.transform.position = position;
            item.transform.rotation = transform.rotation;

            _nbItemsSpawned++;
        }
    }

    Vector3 GetNewPosition()
    {
        Vector3 tmp = transform.position;
        tmp.x = UnityEngine.Random.Range(MinX, MaxX);
        tmp.y = UnityEngine.Random.Range(MinY, MaxY);
        return tmp;
    }

    IEnumerator SpawnCoroutine()
    {
        while (_nbItemsSpawned < MaxItems)
        {
            SpawnItem();
            yield return new WaitForSeconds(0f);
        }
    }
}
