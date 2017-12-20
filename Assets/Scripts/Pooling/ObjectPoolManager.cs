using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : Singleton<ObjectPoolManager> {

    private Dictionary<string, ObjectPool> pools = new Dictionary<string, ObjectPool>();

	// Récupère l'ObjectPool dans le dictionnaire
    private ObjectPool GetPool(GameObject obj) {
        ObjectPool pool;
        if (!pools.TryGetValue(obj.name, out pool)) {
            pool = new ObjectPool(obj);
            pools.Add(obj.name, pool);
        }
        return pool;
    }

	// Récupère un objet
    public GameObject GetObject(GameObject obj) {
        return GetPool(obj).GetObject();
    }

	// Pool un objet
    public bool PoolObject(GameObject obj) {
        return GetPool(obj).PoolObject(obj);
    }

}
