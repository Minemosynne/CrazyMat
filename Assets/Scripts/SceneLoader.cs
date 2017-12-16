using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // Scène de combat
    public string FightScene;

    // Scène de départ - village
    public string VillageScene;

    // Scène de jeu - carte
    public string GameScene;

    // TODO menu


    void Start()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(VillageScene);
    }

    public void EnterWorld()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void StartFight(GameObject enemy)
    {
        // SceneManager.LoadScene(FightScene);
        // Debug.Log("Scene : " + SceneManager.GetSceneByName(FightScene));
        SceneManager.MoveGameObjectToScene(enemy, SceneManager.GetSceneByName(FightScene));
    }
}
