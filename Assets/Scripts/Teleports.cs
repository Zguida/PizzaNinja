using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Teleports : MonoBehaviour
{
    [SerializeField] private string levelToLoad;

    void OnTriggerEnter(Collider player)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(levelToLoad);
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
