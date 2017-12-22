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
                    YPos = posY
                };
                // Instancie les ScreenRegion nécessaires pour le mouvement de la caméra
                Instantiate(ScreenRegion, new Vector3(posX, posY), Quaternion.identity);
                posX += MiniMapWidth;
            }
            posX = transform.position.x;
            posY += MiniMapHeight;
        }
    }
}
