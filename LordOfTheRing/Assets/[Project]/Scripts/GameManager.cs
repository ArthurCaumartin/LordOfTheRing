using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string _gameScene = "GameScene";
    public string _endScene = "EndScene";
    public int MaxLevel = 5;
    public int CurrentLevel = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else
            Instance = this;
    }

    public void OnUpLevel(InputValue value)
    {
        if (value.Get<float>() > 0)
            CurrentLevel++;
    }
}