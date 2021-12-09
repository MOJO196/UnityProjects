using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public void NextScene()
    {
        StartCoroutine(SetActiveScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator SetActiveScene(int sceneID)
    {
        SceneData.currentScene = sceneID;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
    }
}
