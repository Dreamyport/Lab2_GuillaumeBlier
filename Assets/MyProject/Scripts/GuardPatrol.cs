using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    // Attributs:
    private bool _caughtSomeone;
    private bool _playerCaught;
    private float _horizontalValue = 1.0f;
    private float _verticalValue = 1.0f;

    [Header("Patrol")]
    [SerializeField] private GameObject _spotLight;
    [SerializeField] private Material _guardCaughtMat;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private bool _isHorizontal;
    [SerializeField] private float _guardSpeed = 100f;
    [SerializeField] private float _guardRotationSpeed = 100f;

    // Méthodes privées:
    private void Start() 
    {
        _caughtSomeone = false;
        _playerCaught = false;
    }

    private void FixedUpdate()
    {
        if (!_caughtSomeone)
        {
            MoveGuard();
        }
        else 
        {
            _rb.velocity = Vector3.zero;
        }
    }

    private void MoveGuard() 
    {
        Vector3 direction;

        if (!_isHorizontal)
        {
            direction = new Vector3(0, 0, _horizontalValue);
        }
        else 
        {
            direction = new Vector3(_verticalValue, 0, 0);
        }

        _rb.velocity = direction.normalized * Time.fixedDeltaTime * _guardSpeed;

        // Code du changement de direction pris par Ketra Games dans la vidéo: https://www.youtube.com/watch?v=BJzYGsMcy8Q&ab_channel=KetraGames
        Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _guardRotationSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Copy")
        { 
            _caughtSomeone = true;
        }
        if (other.gameObject.tag == "Player") 
        {
            _caughtSomeone = true;
            _playerCaught = true;
            CaughtSomeone();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Copy" && !_playerCaught)
        {
            _caughtSomeone = false;
        }
    }

    // Méthodes publiques:
    public void SetDirection() 
    {
        _horizontalValue *= -1.0f;
        _verticalValue *= -1.0f;
    }

    public void SetCaughtSomeone(bool caught) 
    {
        _caughtSomeone = caught;
        _playerCaught = caught;
    }

    public void CaughtSomeone() 
    {
        _spotLight.GetComponent<Light>().color = Color.red;
        gameObject.GetComponentInChildren<MeshRenderer>().material = _guardCaughtMat;
    }
}
