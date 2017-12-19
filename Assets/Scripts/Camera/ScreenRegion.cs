using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRegion : MonoBehaviour {

    private Rigidbody2D _rb2d;
    private BoxCollider2D _collider;

    private void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider2D>();
        _rb2d = gameObject.AddComponent<Rigidbody2D>();
        _rb2d.isKinematic = true;
    }

    private void SetNewCameraBounds()
    {
        GameCameraController camera = Camera.main.gameObject.GetComponent<GameCameraController>();
        camera.SetNewBounds(_collider.bounds);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SetNewCameraBounds();
        }
    }

}
