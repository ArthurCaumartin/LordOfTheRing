using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _ballRb;
    [SerializeField] private CameraZoom _cameraZoom;
    [Space]
    [SerializeField] private float _chargeDuration = 2f;
    [Space]
    [SerializeField] private float _minForce = 5f;
    [SerializeField] private float _maxForce = 20f;
    [SerializeField] AnimationCurve _forceCurve;
    [Space]
    [SerializeField] private Transform _launchPivot;
    [SerializeField] private Transform _maxUpTransform;
    private float _currentForce;
    private float _chargeTime;
    private bool _isCharging = false;
    private bool _isHoldingBall = true;


    private void Update()
    {
        Charge();

        if (_isHoldingBall)
        {
            _ballRb.position = _launchPivot.position;
            _ballRb.linearVelocity = Vector2.zero;
            _ballRb.angularVelocity = 0;
        }
    }

    private void Charge()
    {
        CanvasManager.Instance.UpdateCharge(_chargeTime);
        if (_isCharging)
        {
            _chargeTime += Time.deltaTime * (1 / _chargeDuration);
            _isHoldingBall = true;
        }
        else
        {
            if (_chargeTime > 0)
                Launch();

            _chargeTime = 0;
        }

        _currentForce = Mathf.Lerp(_minForce, _maxForce, _forceCurve.Evaluate(_chargeTime));
        _launchPivot.right = Vector3.Lerp(Vector3.right, _maxUpTransform.right, _chargeTime);
    }

    private void Launch()
    {
        _ballRb.AddForce(_launchPivot.right * _currentForce * _cameraZoom.GetForceMult(), ForceMode2D.Impulse);
        _ballRb.AddTorque(Random.Range(-3, -5f), ForceMode2D.Impulse);
        _isHoldingBall = false;
    }

    public void OnCharge(InputValue value)
    {
        _isCharging = value.Get<float>() > 0.5f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawRay(_launchPivot.position, _launchPivot.right * _maxForce);
        Gizmos.DrawSphere(_launchPivot.position + _launchPivot.right * _currentForce, 0.2f);
    }
}
