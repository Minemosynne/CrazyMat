using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRegion : MonoBehaviour {

    public int Width;
    public int Height;

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
        Vector3 heroPosition = collision.gameObject.transform.position;
        if(collision.gameObject.tag == "Player")
        {
            SetNewCameraBounds();
        }
    }

}
