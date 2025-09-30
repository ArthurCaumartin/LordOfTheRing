using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    
    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
        GameManager.Instance.CurrentLevel = 0;
    }
}