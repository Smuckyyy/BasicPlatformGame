using UnityEngine;
using TMPro;

public class ScoreManagerGUI : MonoBehaviour
{
    public TMP_Text guiCurScore;
    public TMP_Text guiHighScore;
    public GameObject player;
    private PlayerController pcScript;
    private void Start()
    {
        pcScript = GetComponent<PlayerController>();
    }
    public void setGUICurScore(int score)
    {
        guiCurScore.text = "Score: " + pcScript.getPlayerScore().ToString();
    }

    public void setGUIHighScore(int score)
    {

    }
}
