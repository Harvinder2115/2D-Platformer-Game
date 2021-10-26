using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button exitgame;
    //private float restarDelay = 1f;

    private void Awake() 
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        exitgame.onClick.AddListener(doExitGame);
    }

        private void ReloadLevel()
    {
        //gameObject.GetComponent<GameManager>();
        //Invoke("Restart", restarDelay);
        SceneManager.LoadScene(1);  
    }

    public void doExitGame()
    {
        Application.Quit();
    }

    // public void GameOver()
    // {
    //     gameObject.SetActive(true);
    // }
}
