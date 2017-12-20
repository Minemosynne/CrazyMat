﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Scène de combat
    public string FightScene;

    // Scène de départ - village
    public string VillageScene;

    // Scène de jeu - carte
    public string GameScene;

    // Scène de menu
	public string MenuScene;

	// Lancement de la scène Depart
    public void NewGame() {
        SceneManager.LoadScene(VillageScene);
    }

	// Lancement de la scène Jeu
    public void EnterWorld() {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(GameScene);
    }

	// Lancement de la scène FightScene
    public void StartFight(GameObject enemy) {
        DontDestroyOnLoad(enemy);
        SceneManager.LoadScene(FightScene);
    }

	// Retour à la scène Depart en cas de perte du combat
    public void LoseFight() {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        SceneManager.LoadScene(VillageScene);
    }

	// Retour à la scène Jeu en cas de gain du combat
    public void WinFight() {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        SceneManager.LoadScene(GameScene);
    }
}
