using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    private float timer = 5;
    private float timeElapsed = 0;
    public string sceneName = "";

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timer)
        {
            Debug.Log(timeElapsed);
            resetGame();
            timer = 0;
        }
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void resetGame()
    {
        if (sceneName == "Credits")
        {
            SceneManager.LoadScene(0);
        }
    }

}
