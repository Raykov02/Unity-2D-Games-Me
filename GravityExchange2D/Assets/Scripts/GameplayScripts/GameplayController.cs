using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public static class Usable
{
    public static int score=0;
    public static int enemiesKilled = 0;
    public static int jumpsPressed = 0;
}
public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    public Text scoreText;
    public Text highscoreText;
    private GameObject pausePan;
    private void Awake()
    {

        if (instance == null)
            instance = this;
        Usable.score = 0;
    }
    void Start()
    {
        StartCoroutine(countScore());
        pausePan = GameObject.Find("pausePan");
        pausePan.SetActive(false);
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator countScore()
    {
        if (Usefull.isAlive)
        {
            yield return new WaitForSeconds(0.2f);
            Usable.score++;
            scoreText.text = Usable.score.ToString();
            if (Usable.score > PlayerPrefs.GetInt("Highscore", 0))
            {
                PlayerPrefs.SetInt("Highscore", Usable.score);
                highscoreText.text = Usable.score.ToString();
            }
            StartCoroutine(countScore());
        }      
    }
    public void restartLevel()
    {
        SceneManager.LoadScene("GamePlay");
        Time.timeScale = 1f;
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void pauseGame()
    {
        pausePan.SetActive(true);
        Time.timeScale = 0f;
    }
    public void unpauseGame()
    {
        pausePan.SetActive(false);
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
