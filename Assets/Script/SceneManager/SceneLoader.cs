using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class SceneLoader : PersistenceSingleton<SceneLoader>
{
    [SerializeField] private const string GamePlayScene = "GamePlay";
    [SerializeField] private const string MainMenuScene = "MainMenu";
    // Start is called before the first frame update
    public void LoadGamePlay()
    {
        StartCoroutine(LoadAsyncScene(GamePlayScene));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadAsyncScene(MainMenuScene));
    }
    IEnumerator LoadAsyncScene(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
