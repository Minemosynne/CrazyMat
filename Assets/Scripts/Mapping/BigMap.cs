using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMap : Map
{

    public int Columns;
    public int Rows;
    private int _nbMaps;

    public int MiniMapWidth;
    public int MiniMapHeight;

    public GameObject bigMap;
    public GameObject MiniMap;
    public GameObject ScreenRegion;

    public MiniMap currentMap;
    public MiniMap[] MiniMaps;
    public MiniMap[,] grid;
    
    void Start()
    {
        _nbMaps = Columns * Rows;
        // Create the GameObject Big Map
        //Useful??
        bigMap = new GameObject("BigMap");

        // Create the grid of Mini Maps
        CreateGrid();

        // Create the array of Mini Maps
        CreateMiniMaps();

        // Initialize the Mini Maps
        InitializeMiniMaps();

        //Met les bonnes boundaries au mouvement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PersoMovement>().SetBoundaries();
        //Positionne le joueur sur la map
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-(Width / 2) - 2, -(Height / 2) - 2, 0);
    }

    void CreateGrid()
    {
        //For the tiles
        /*grid = new MiniMap[Columns, Rows];
        for (int i = 0; i < Columns; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                grid[i, j] = new MiniMap();

            }
        }*/
    }

    void CreateMiniMaps()
    {
        MiniMaps = new MiniMap[_nbMaps];
        float posX = transform.position.x;
        float posY = transform.position.y;
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                MiniMaps[i] = new MiniMap
                {
                    XPos = posX,
                    YPos = posY
                };
                //Instantie les screen region nécessaires pour le mouvement de la caméra
                Instantiate(ScreenRegion, new Vector3(posX, posY), Quaternion.identity);
                //Instantiate(MiniMap, new Vector3(posX, posY), transform.rotation);
                posX += MiniMapWidth + 1;
            }
            posX = transform.position.x;
            posY += MiniMapHeight + 1;
        }
    }

    void InitializeMiniMaps()
    {
       /* for (int i = 0; i < MiniMaps.Length; i++)
        {
            currentMap = MiniMaps[i];
            // Initialize its width
            for (int j = 0; j < Columns; j++)
            {
                float coordX = currentMap.XPos + j;
                // Initialize its height
                for (int k = 0; k < Rows; k++)
                {
                    float coordY = currentMap.YPos + k;
                    grid[(int)coordX, (int)coordY] = MiniMaps[i];
                }
            }
        }*/
    }
}
