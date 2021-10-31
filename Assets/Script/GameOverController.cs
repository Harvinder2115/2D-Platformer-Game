using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    public Button exitgame;
    public Button lobby;
    //private float restarDelay = 1f;

    private void Awake() 
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
        exitgame.onClick.AddListener(doExitGame);
        lobby.onClick.AddListener(mainmenu);
    }

        private void ReloadLevel()
    {
        //gameObject.GetComponent<GameManager>();
        //Invoke("Restart", restarDelay);
        //SceneManager.LoadScene(1);
        //SceneManager.GetActiveScene().buildIndex;
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.buildIndex);
    }
        

    public void doExitGame()
    {
        Application.Quit();
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
