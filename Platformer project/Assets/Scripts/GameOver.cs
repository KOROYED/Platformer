using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsPlayedUI;
    public Text gradeUI;
    bool gameOver;

    void Start()
    {
        FindObjectOfType<PlayerMovement>().OnPlayerHitDoor += OnGameOver;
    }


    void Update()
    {
        if (gameOver)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        secondsPlayedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        if (Time.timeSinceLevelLoad <= 20)
        {
            gradeUI.text = "Gold";
            gradeUI.color = new Color(100f / 255.0f, 84f / 255.0f, 0 / 255.0f);
        }
        else if (Time.timeSinceLevelLoad >= 20 && Time.timeSinceLevelLoad <= 30)
        {
            gradeUI.text = "Silver";
            gradeUI.color = new Color(75f / 255.0f, 75f / 255.0f, 75f / 255.0f);
        }
        else if (Time.timeSinceLevelLoad >= 30)
        {
            gradeUI.text = "Bronze";
            gradeUI.color = new Color(80f / 255.0f, 50f / 255.0f, 20f / 255.0f);
        }
        gameOver = true;
        gameOverScreen.SetActive(true);
    }
}
