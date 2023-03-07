using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Attributs:
    private bool _canRotate;

    [Header("Movement")]
    [SerializeField] private float _zSpeed = 2.0f;

    // Méthodes privées:
    private void Start()
    {
        _canRotate = true;
    }

    private void FixedUpdate()
    {
        if (_canRotate) 
        {
            transform.Rotate(0f, 0f, _zSpeed);
        }
    }

    public void SetCanRotate(bool canRotate) 
    {
        _canRotate = canRotate;
    }
}
