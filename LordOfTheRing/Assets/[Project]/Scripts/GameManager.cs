using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int MaxLevel = 5;
    public int CurrentLevel
    {
        get => level;
        set
        {
            if (value >= MaxLevel)
                EndScene();
            else
            {
                if (value == 3)
                    AudioManager.Instance.PlaySound(AudioManager.Instance.lvlUp);
                level = value;
            }
        }
    }

    private int level;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
    }

    public void OnUpLevel(InputValue value)
    {
        if (value.Get<float>() > 0)
            CurrentLevel++;
    }

    public void EndScene()
    {
        SceneManager.LoadScene("EndGame");
    }
}
