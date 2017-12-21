using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMovement : MonoBehaviour
{
	
    [SerializeField]
	// Vitesse de déplacement
    private float _speed = 1f;

    private Rect _bounds;

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
        velocity *= _speed * Time.deltaTime;
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

    //Pour empêcher je joueur de sortir de la map
    void ClampPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(transform.position.x, _bounds.xMin, _bounds.xMax);
        newPosition.y = Mathf.Clamp(transform.position.y, _bounds.yMin, _bounds.yMax);
        transform.position = newPosition;
    }

    //Pour récupérer les bounds de la nouvelle map
    public void SetBoundaries()
    {
        Map Map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        _bounds.x = Map.MinX + 1;
        _bounds.y = Map.MinY + 1;
        _bounds.width = Map.Width - 2;
        _bounds.height = Map.Height - 2;
    }
}
