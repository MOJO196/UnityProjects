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
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public int GetTotalNumberOfScenes()
    {
        return SceneManager.sceneCountInBuildSettings;
    }
    
    public void NextScene()
    {
        SceneData.currentScene = SceneManager.GetActiveScene().buildIndex;        
        StartCoroutine(SetActiveScene(SceneData.currentScene+1));
    }

    public void SetScene(int sceneID)
    {
        StartCoroutine(SetActiveScene(sceneID));
    }

    IEnumerator SetActiveScene(int sceneID)
    {
        yield return new WaitForSeconds(1); //Transition
        SceneManager.LoadScene(sceneID);
    }
}
