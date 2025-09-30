using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
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
            _audioSource.PlayOneShot(_clips[Random.Range(0, _clips.Count)]);
        }
    }
}
