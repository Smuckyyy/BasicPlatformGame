using UnityEngine;
using TMPro;

public class ScoreManagerGUI : MonoBehaviour
{
    public TMP_Text guiCurScore;
    public TMP_Text guiHighScore;
    public GameObject player;
    private PlayerController pcScript;
    private HighscoreManager hsmScript;
    private void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        hsmScript = GetComponent<HighscoreManager>();
        pcScript.setPlayerHighScore(hsmScript.readHighscore());
        setGUIHighScore();

    }
    public void setGUICurScore()
    {
        guiCurScore.text = "Score: " + pcScript.getPlayerScore().ToString();
        if (isHighscore())
        {
            setGUIHighScore();
            hsmScript.writeHighscore();
        }
        
    }

    public void setGUIHighScore()
    {
        guiHighScore.text = "Highscore: " + pcScript.getPlayerHighScore().ToString();
    }

    public bool isHighscore()
    {
        if (pcScript.getPlayerHighScore() < pcScript.getPlayerScore())
        {
            //Change the highscore that is connected to the playerController
            pcScript.setPlayerHighScore(pcScript.getPlayerScore());
            //We have a new high score so return true
            return true;
        }
        else
        {
            return false;
        }
    }
}
