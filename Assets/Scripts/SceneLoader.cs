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

    public void NewGame()
    {
        SceneManager.LoadScene(VillageScene);
    }

    public void EnterWorld()
    {
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
        SceneManager.LoadScene(GameScene);
    }

    public void StartFight(GameObject enemy)
    {
        DontDestroyOnLoad(enemy);
        SceneManager.LoadScene(FightScene);
    }

    public void LoseFight()
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        SceneManager.LoadScene(VillageScene);
    }

    public void WinFight()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        SceneManager.LoadScene(GameScene);
    }
}
