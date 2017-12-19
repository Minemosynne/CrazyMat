using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Map
{
    public GameObject Player;
    public SceneLoader SceneLoader;
    
    void Update()
    {
        if(Player.transform.position.x >= (Width/2)-2)
        {
            //SceneLoader.EnterWorld();
        }
    }
}
