using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        int gameAudioCount = FindObjectsOfType<DontDestroyAudio>().Length;
        if (gameAudioCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GameReset()
    {
        Destroy(gameObject);
    }
}
