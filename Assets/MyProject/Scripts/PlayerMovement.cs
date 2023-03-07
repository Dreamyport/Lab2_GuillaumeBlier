using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Attributs:
    private bool _madeCopy = false;
    private GameObject _copyMade;

    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _copy;
    [SerializeField] private GameObject _copySpawn;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 8f;
    [SerializeField] private float _sprintSpeed = 12f;
    [SerializeField] private float _rotationSpeed = 100f;
    [SerializeField] private float _gravity = 9.81f;
    [SerializeField] private float _gravityCopy = 9.81f;

    // Méthodes privées:
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E) && !_madeCopy)
        {
            _madeCopy = true;
            CreateCopy();
        }
        else if (Input.GetKeyDown(KeyCode.E) && _madeCopy) 
        {
            _madeCopy = false;
            DeleteCopy();
        }
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
        _rb.velocity = direction.normalized * Time.fixedDeltaTime * speed;
        _rb.AddForce(Vector3.down * _gravity);

        if (direction.normalized != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void CreateCopy() 
    {
        _copyMade = Instantiate(_copy, _copySpawn.transform.position, _copySpawn.transform.rotation);
    }

    private void DeleteCopy() 
    {
        _copyMade.GetComponent<Rigidbody>().useGravity = true;
        _copyMade.GetComponent<Rigidbody>().AddForce(Vector3.down * _gravityCopy);
        Destroy(_copyMade, 0.1f);
    }


    // Méthodes publiques:
    public bool GetMadeCopy() 
    {
        return _madeCopy;
    }
}
