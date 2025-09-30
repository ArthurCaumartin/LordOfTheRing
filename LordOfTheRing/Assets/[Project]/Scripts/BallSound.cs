using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _minVelocityToPlay = 1f;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_rigidbody2D.linearVelocity.magnitude > _minVelocityToPlay)
        {
            _audioSource.PlayOneShot(_clip);
        }
    }
}