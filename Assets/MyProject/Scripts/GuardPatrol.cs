using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    // Attributs:
    private int _indexPoint;
    [Header("Patrol")]
    [SerializeField] private List<Transform> _patrolPoints = new List<Transform>();
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _guardSpeed = 100f;
    [SerializeField] private float _guardRotationSpeed = 100f;

    // Méthodes privées:
    private void Start() 
    {
        _indexPoint= 0;
    }

    private void FixedUpdate()
    {

        MoveGuard(); 
    }

    private void MoveGuard() 
    {
        Vector3 direction = _patrolPoints[_indexPoint].position;
        direction.Normalize();

        _rb.velocity = direction * Time.fixedDeltaTime * _guardSpeed;

        // Code du changement de direction pris par Ketra Games dans la vidéo: https://www.youtube.com/watch?v=BJzYGsMcy8Q&ab_channel=KetraGames

        if (direction != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _guardRotationSpeed * Time.fixedDeltaTime);
        }
    }

    // Méthodes publiques:
    public void SetNextPoint() 
    {
        _indexPoint++;

        if (_indexPoint >= _patrolPoints.Count) 
        {
            _indexPoint = 0;
        }
    }
}
