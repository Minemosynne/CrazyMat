using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 1f;

    public Rect bounds;

    void Awake()
    {
        // bounds = ScreenToRect (1f);
		bounds.x = -0.5f;
		bounds.y = -1.5f;
		bounds.width = 49f;
		bounds.height = 49f;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 velocity = GetAxisVector();
        velocity *= speed * Time.deltaTime;
        // transform.position += velocity;
        transform.Translate(velocity);
        ClampPosition ();
        // Debug.Log ("X : " + transform.position.x + ", Y :" + transform.position.y);
    }

    Vector3 GetAxisVector()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");
        float vDirection = Input.GetAxisRaw("Vertical");
        return new Vector3(hDirection, vDirection, 0);
    }

    void ClampPosition() {
		Vector3 newPosition = transform.position;
		newPosition.x = Mathf.Clamp (transform.position.x, bounds.xMin, bounds.xMax);
		newPosition.y = Mathf.Clamp (transform.position.y, bounds.yMin, bounds.yMax);
		transform.position = newPosition;
	}

    /* Rect ScreenToRect(float margin) {
		Camera cam = Camera.main;
		Vector3 bottomLeft = cam.ScreenToWorldPoint (Vector3.zero);
		Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

		Rect rect = Rect.MinMaxRect (bottomLeft.x, bottomLeft.y, topRight.x, topRight.y);
		rect.x += margin;
		rect.y += margin;
		rect.width -= margin * 2;
		rect.height -= margin * 2;

		return rect;
	} */
}
