using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    //private float restarDelay = 1f;

    private void Awake() 
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }

        private void ReloadLevel()
    {
        //gameObject.GetComponent<GameManager>();
        //Invoke("Restart", restarDelay);
        SceneManager.LoadScene(1);  
    }

    // public void PlayerDied()
    // {
    //     gameObject.SetActive(true);
    // }

    // public void GameOver()
    // {
    //     gameObject.SetActive(true);
    // }
}
