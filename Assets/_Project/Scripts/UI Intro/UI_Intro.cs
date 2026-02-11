using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Intro : MonoBehaviour
{

    public void NewGameButton()
    {
        SceneManager.LoadScene(Utility._sceneLevel1);
    }


    public void ExitGameButton()
    {
        Debug.Log("Exit Game");
    }
   
}
