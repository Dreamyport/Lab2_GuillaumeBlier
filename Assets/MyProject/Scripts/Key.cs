using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Attributs:
    private bool _hasKey;
    private bool _triggerOnce;

    [Header("References")]
    [SerializeField] private Transform _inventory;

    // Méthodes privées:
    private void Start()
    {
        _hasKey = false;
        _triggerOnce = false;
    }
    private void Update()
    {
        if (_hasKey) 
        {
            GetComponent<Transform>().position = _inventory.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_triggerOnce)
        {
            _hasKey = true;
            _triggerOnce = true;
        }
    }
}
