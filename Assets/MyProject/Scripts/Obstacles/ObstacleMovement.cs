using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    // Attributs:
    private bool _canMove;

    private float _horizontalValue = 1.0f;
    private float _verticalValue = 1.0f;

    [Header("Movement")]
    [SerializeField] private float _rotationSpeed = 2.0f;
    [SerializeField] private float _translateSpeed = 2.0f;

    [Header("Type")]
    [SerializeField] private bool _rotation = false;
    [SerializeField] private bool _isHorizontal;
    [SerializeField] private bool _isGuard;

    // Méthodes privées:
    private void Start()
    {
        _canMove = true;
    }

    private void FixedUpdate()
    {
        if (_canMove) 
            Movement(_rotation);
        else if (_isGuard)
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Movement(bool rotation)
    {
        // Mouvement de rotation.
        if(rotation)
            transform.Rotate(0.0f, 0.0f, _rotationSpeed);

        // Mouvement de translation.
        else
            Translate();
    }

    private void Translate()
    {
        Vector3 direction;

        if (!_isHorizontal)
            direction = new Vector3(0.0f, 0.0f, _horizontalValue);
        else 
            direction = new Vector3(_verticalValue, 0.0f, 0.0f);

        gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * Time.fixedDeltaTime * _translateSpeed;

        // Only rotate the object, if it's a guard.
        if (_isGuard)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    // Méthodes publiques:
    public void SetCanMove(bool canMove) 
    {
        _canMove = canMove;
    }

    public void ChangeDirection() 
    {
        _horizontalValue *= -1.0f;
        _verticalValue *= -1.0f;
    }
}
