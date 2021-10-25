using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restarDelay = 1f;
    
    public void levelCompleted()
    {
        Debug.Log("Level Completed");
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restarDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
