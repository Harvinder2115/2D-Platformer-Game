using UnityEngine;
//using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public string Level1;

    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        if (GetLevelStatus(Level1) == LevelStatus.Locked)
        {
            SetLevelStatus(Level1, LevelStatus.Unlocked);
        }    
    }

    public void MarkCurrentLevelComplete()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //set level status to Complete
        SetLevelStatus(currentScene.name, LevelStatus.Completed);

        // unlock next level
        int nextSceneIndex = currentScene.buildIndex + 1;
        Scene nextScene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);//GetSceneAt(nextSceneIndex);
        SetLevelStatus(nextScene.name, LevelStatus.Unlocked);

        //Move to next Level
        SceneManager.LoadScene(nextSceneIndex);
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
}
