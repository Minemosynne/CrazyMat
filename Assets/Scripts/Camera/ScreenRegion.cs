using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRegion : MonoBehaviour
{

    public int Width;
    public int Height;

    private Rigidbody2D _rb2d;
    private BoxCollider2D _collider;

    private void Awake()
    {
        //Récupère collider pour avoir les bounds de la région -> pour positionner la caméra
        _collider = gameObject.GetComponent<BoxCollider2D>();
        _rb2d = gameObject.AddComponent<Rigidbody2D>();
        _rb2d.isKinematic = true;
    }

    private void SetNewCameraBounds()
    {
        GameCameraController camera = Camera.main.gameObject.GetComponent<GameCameraController>();
        camera.SetNewBounds(_collider.bounds);
    }

    //Enclenchée quand héros rentre dans une nouvelle région
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 heroPosition = collision.gameObject.transform.position;
        if (collision.gameObject.tag == "Player")
        {
            //Pour repositionner le héros dans la nouvelle région
            //Sinon il est une case en dehors, dû au Time.timeScale = 0f dans GameCameraController
            if (heroPosition.x <= transform.position.x - Width / 2)
            {
                heroPosition.x += 1;
            }
            if (heroPosition.x >= transform.position.x + Width / 2)
            {
                heroPosition.x -= 1;
            }
            if (heroPosition.y <= transform.position.y - Height / 2)
            {
                heroPosition.y += 1;
            }
            if (heroPosition.y >= transform.position.y + Height / 2)
            {
                heroPosition.y -= 1;
            }
            collision.gameObject.transform.position = heroPosition;
            //Indique les bounds de la nouvelle région à la caméra
            SetNewCameraBounds();
        }
    }

}