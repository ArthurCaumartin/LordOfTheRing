using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ballRb;
    [SerializeField] private float _minForce = 5f;
    [SerializeField] private float _maxForce = 20f;
    [SerializeField] private float _chargeDuration = 2f;
    [SerializeField] private Transform _maxUpTransform;
    private float _currentForce;
    private bool _isCharging = false;


    private void Update()
    {
        if (_isCharging)
        {
            _currentForce += Time.deltaTime * (1 / _chargeDuration);



        }
    }

    private void Launch()
    {

    }

    public void OnCharge(InputValue value)
    {
        _isCharging = value.Get<float>() > 0.5f;
    }
}
