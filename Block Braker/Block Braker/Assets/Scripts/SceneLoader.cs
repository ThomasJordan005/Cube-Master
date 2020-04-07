using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Menu 1");
        FindObjectOfType<GameStatus>().GameReset();
        FindObjectOfType<Level>().GameReset();
        FindObjectOfType<DontDestroyAudio>().GameReset();
        //FindObjectOfType<LoseCollider>().GameReset();

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
