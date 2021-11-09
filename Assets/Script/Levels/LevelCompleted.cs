using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D levelDoor)
    {
        if (levelDoor.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Level Finished by the Player");
            //LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            //gameObject.GetComponent<>;
            LevelManager.Instance.MarkCurrentLevelComplete();
            //SceneManager.LoadScene(2);
        }
    }
}

