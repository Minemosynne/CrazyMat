using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageCameraController : MonoBehaviour
{

    public Transform Hero;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    private void Update()
    {
        Vector3 HeroPosition = Hero.position;
        //Empêcher le joueur de sortir de la map
        HeroPosition.x = Mathf.Clamp(HeroPosition.x, MinX, MaxX);
        HeroPosition.y = Mathf.Clamp(HeroPosition.y, MinY, MaxY);

        HeroPosition.z = transform.position.z;

        transform.position = HeroPosition;
    }

}