using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    { 
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    { 
        print("EXIT GAME!");
        Application.Quit();
    }
    
}
