using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Map
{
    public GameObject Player;
    public SceneLoader SceneLoader;
    
    void Update()
    {	
		// Passe à la scène de Jeu lorsque le héros arrive aux limites à droite du village
        if (Player.transform.position.x >= (Width/2)-2)
        {
            SceneLoader.EnterWorld();
        }
    }
}
