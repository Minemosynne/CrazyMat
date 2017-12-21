using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Map
{
    public GameObject Player;
    public SceneLoader SceneLoader;
    
    void Update()
    {
        //Charge la scène de jeu si le joueur touche la limite droite de la map Village
        if (Player.transform.position.x >= (Width/2)-2)
        {
            SceneLoader.EnterWorld();
        }
    }
}
