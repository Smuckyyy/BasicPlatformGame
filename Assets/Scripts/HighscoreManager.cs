using UnityEngine;

public class HighscoreManager : MonoBehaviour
{
    public GameObject player;
    PlayerController pcScript;

    ScoreManagerGUI scoreManagerScript;


    private void Start()
    {
        //I have to have reference to the player to do this
        //Becuase this script is not attachted to the same object
        //as the player
        pcScript = player.GetComponent<PlayerController>();
        //I can do this because thjis script is attachted to the same
        //object as the ScoreManagerGUI script
        scoreManagerScript = GetComponent<ScoreManagerGUI>();
    }

    public void writeHighscore()
    {
        //We can write simple things to a standard text file by using the pleyerprefs
        PlayerPrefs.SetInt("Highscore1", pcScript.getPlayerHighScore());
    }

    public int readHighscore()
    {
        int highscoreFromFile = PlayerPrefs.GetInt("Highscore1", 0);

        return highscoreFromFile;
    }
}
