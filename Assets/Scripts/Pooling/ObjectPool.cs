using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {
	
    public Queue<GameObject> poolQueue = new Queue<GameObject>();

    private GameObject prefab;

    public ObjectPool(GameObject pref) {
        this.prefab = pref;
    }

	// Récupère un objet dans la Queue ou l'instancie
    public GameObject GetObject() {
        GameObject go;
        if (poolQueue.Count == 0) {
            go = GameObject.Instantiate<GameObject>(prefab);
            go.name = prefab.name;
        }
        else {
            go = poolQueue.Dequeue();
        }
        return go;
    }

	// Rajoute un objet à la Queue
    public bool PoolObject(GameObject obj) {
        if (obj.name != prefab.name)
            return false;
        poolQueue.Enqueue(obj);
        return true;
    }
}
