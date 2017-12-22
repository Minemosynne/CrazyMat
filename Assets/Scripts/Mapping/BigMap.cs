using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMap : Map {

    public int Columns;
    public int Rows;
    private int _nbMaps;

    public int MiniMapWidth;
    public int MiniMapHeight;

    public GameObject MiniMap;
    public GameObject ScreenRegion;

    public MiniMap[] MiniMaps;
    public GameObject[] Grounds;
    
    void Start() {
        _nbMaps = Columns * Rows;

        // Crée le tableau de Mini Maps et initalise les Mini maps
        CreateMiniMaps();

        // Met les bonnes boundaries au mouvement
        GameObject.FindGameObjectWithTag("Player").GetComponent<PersoMovement>().SetBoundaries();
    }

    void CreateMiniMaps() {
        MiniMaps = new MiniMap[_nbMaps];
        float posX = transform.position.x;
        float posY = transform.position.y;
        for (int i = 0; i < Rows; i++) {
            for (int j = 0; j < Columns; j++) {
                MiniMaps[i] = new MiniMap {
                    XPos = posX,
                    YPos = posY,
                    Ground = ChooseAGround()
                };
                // Instancie les ScreenRegion nécessaires pour le mouvement de la caméra
                Instantiate(ScreenRegion, new Vector3(posX, posY), Quaternion.identity);
                Instantiate(MiniMaps[i].Ground, new Vector3(posX + 4, posY - 4), Quaternion.identity);
                posX += MiniMapWidth;
            }
            posX = transform.position.x;
            posY += MiniMapHeight;
        }
    }

    private GameObject ChooseAGround()
    {
        return Grounds[Random.Range(0, Grounds.Length)];
    }

	/*void CreateGrid() {
        grid = new MiniMap[Columns, Rows];
        for (int i = 0; i < Columns; i++) {
            for (int j = 0; j < Rows; j++) {
                grid[i, j] = new MiniMap();
            }
        }
    }*/

    /* void InitializeMiniMaps() {
	   public MiniMap currentMap;
       for (int i = 0; i < MiniMaps.Length; i++) {
            currentMap = MiniMaps[i];
            // Initialize its width
            for (int j = 0; j < Columns; j++) {
                float coordX = currentMap.XPos + j;
                // Initialize its height
                for (int k = 0; k < Rows; k++) {
                    float coordY = currentMap.YPos + k;
                    grid[(int)coordX, (int)coordY] = MiniMaps[i];
                }
            }
        }
    }*/
}
