using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMovement : MonoBehaviour
{
	
    [SerializeField]
	// Vitesse de déplacement
    float speed = 1f;

    public Rect bounds;

    void Awake() {
        SetBoundaries();
    }
    
    void Update() {
        Move();
    }

	// Méthode de déplacement du joueur
    void Move() {
		Vector3 velocity = new Vector3();

		// Si le joueur se déplace vers la droite ou vers la gauche
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			velocity = GetAxisVector (1);
		}

		// Si le joueur se déplace vers le haut ou vers le bas
		else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow)) {
			velocity = GetAxisVector (2);
		}

		// Appliquer le déplacement
        velocity *= speed * Time.deltaTime;
        transform.Translate(velocity);
        ClampPosition ();
    }

	// Récupère le déplacement horizontal ou vertical dans un vecteur
	Vector3 GetAxisVector(float direct) {
		if (direct == 1) {
			float hDirection = Input.GetAxisRaw ("Horizontal");
			return new Vector3 (hDirection, 0);
		} else {
			float vDirection = Input.GetAxisRaw ("Vertical");
			return new Vector3 (0, vDirection);
		}
    }

    void ClampPosition() {
		Vector3 newPosition = transform.position;
		newPosition.x = Mathf.Clamp (transform.position.x, bounds.xMin, bounds.xMax);
		newPosition.y = Mathf.Clamp (transform.position.y, bounds.yMin, bounds.yMax);
		transform.position = newPosition;
	}

	// Met des limites de déplacement au joueur dans la map
    public void SetBoundaries() {
        Map Map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        bounds.x = -(Map.Width/2) + 1;
        bounds.y = -(Map.Height/2) + 1;
        bounds.width = Map.Width -2;
        bounds.height = Map.Height -2;
    }
}
