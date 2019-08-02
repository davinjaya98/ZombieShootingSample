using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Text highscoreLabel;

    public void OnClickPlayButton ()
    {
        SceneManager.LoadScene("Game");
    }

    void Start ()
    {
        highscoreLabel.text = "" + PlayerPrefs.GetInt("GameHighscore");
        Cursor.lockState = CursorLockMode.None;
    }
}
