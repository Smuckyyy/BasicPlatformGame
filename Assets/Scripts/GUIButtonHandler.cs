using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    public void loadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        //This only works on a full build
        Application.Quit();
        Debug.Log("Exit Application...");
    }
}

