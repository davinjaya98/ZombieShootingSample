using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController me;

    public GameObject enemyPrefab;
    public float spawnRate;
    public Transform[] spawnLocations;
    public Text scoreLabel;

    private float spawnTimer;
    private int score;
    private int highscore;

    public static void GainKillScore ()
    {
        me.score += 3;
        me.scoreLabel.text = "Score : " + me.score;

        if( me.score > me.highscore )
        {
            me.highscore = me.score;
            PlayerPrefs.SetInt("GameHighscore", me.highscore);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        me = this;
        scoreLabel.text = "Score : 0";

        //To Lock the cursor in game, press ESC in editor to get out from the game
        Cursor.lockState = CursorLockMode.Locked;

        //PlayerPrefs is for saving
        highscore = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            // GameObject go = (GameObject)Instantiate(enemyPrefab);
            // go.transform.position = transform.position;

            // enemyPrefab.transform.position = transform.position;
            // Instantiate(enemyPrefab);

            Transform pos = spawnLocations[Random.Range(0, spawnLocations.Length)];
            
            Instantiate(enemyPrefab, pos.position, Quaternion.identity);

            spawnTimer -= spawnRate;
        }
    }
}
