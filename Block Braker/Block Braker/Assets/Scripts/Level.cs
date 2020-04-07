using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    //Serialized for debugging pupuses
    [SerializeField] int breakableBlocks;
    [SerializeField] TextMeshProUGUI gameText;

    //cached reference
    SceneLoader sceneLoader;

    private void Awake()
    {
        int levalCount = FindObjectsOfType<Level>().Length;
        if (levalCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameText.text = ("");
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            FindObjectOfType<Ball>().LockBall();
            Debug.Log("test1");
            gameText.text = ("!!Winner!!");
            StartCoroutine("Wait");

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        gameText.text = ("");
        sceneLoader.LoadNextScene();
    }

    public void GameReset()
    {
        Destroy(gameObject);
    }


}
