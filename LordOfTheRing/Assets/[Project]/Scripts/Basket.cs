using UnityEngine;

public class Basket : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.CurrentLevel++;
        }
    }
}