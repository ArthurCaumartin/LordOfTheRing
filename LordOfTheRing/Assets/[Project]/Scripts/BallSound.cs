using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
    [SerializeField] private float _minVelocityToPlay = 1f;

    private Rigidbody2D _rigidbody2D;
    private float _lastVelocity;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        _lastVelocity = _rigidbody2D.linearVelocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;
        if (impactForce > _minVelocityToPlay)
        {
            int index = Random.Range(0, _clips.Count);
            _audioSource.PlayOneShot(_clips[index]);
        }
    }
}
