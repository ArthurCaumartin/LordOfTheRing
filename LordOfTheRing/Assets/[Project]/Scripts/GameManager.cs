using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int CurrentLevel = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }


    public void OnUpLevel(InputValue value)
    {
        if (value.Get<float>() > 0)
            CurrentLevel++;
    }
}