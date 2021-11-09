using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    public Button playbutton;
    public Button exitgame;
    public GameObject LevelSelection;

    private void Awake() 
    {
        playbutton.onClick.AddListener(PlayGame);
        exitgame.onClick.AddListener(doExitGame);
    }

    private void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }

    public void doExitGame() 
    {
        Application.Quit();
    }
}
