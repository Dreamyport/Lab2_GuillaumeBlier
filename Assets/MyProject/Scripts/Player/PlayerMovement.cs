using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Attributs:
    private bool _madeCopy = false;

    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _copy;
    [SerializeField] private Transform _copyStartLocation;

    [SerializeField] private bool _onIce = false;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _sprintSpeed = 12f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _gravity = 9.81f;

    // Méthodes privées:
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && !_madeCopy)
            CreateCopy();
        else if (Input.GetKeyDown(KeyCode.E) && _madeCopy) 
            DeleteCopy();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float xPos = Input.GetAxis("Horizontal");
        float zPos = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xPos, 0f, zPos);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            PushPlayer(direction, _sprintSpeed);
        }
        else
        {
            PushPlayer(direction, _moveSpeed);
        }
    }

    private void PushPlayer(Vector3 direction, float speed)
    {
        if (!_onIce)
        {
            _rb.velocity = direction.normalized * Time.fixedDeltaTime * speed;
            _rb.AddForce(Vector3.down * _gravity);
        }
        else
        {
            _rb.AddForce(direction.normalized * Time.fixedDeltaTime * speed);
        }

        if (direction.normalized != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void CreateCopy() 
    {
        _copy.transform.position = transform.position;
        _copy.transform.rotation = transform.rotation;
        _madeCopy = true;
    }

    // Méthodes publiques:
    public void DeleteCopy() 
    {
        _copy.transform.position = _copyStartLocation.position;
        _madeCopy = false;
    }

    public bool GetMadeCopy() 
    {
        return _madeCopy;
    }

    public void GameOver()
    {
        this.gameObject.SetActive(false);
    }
}
