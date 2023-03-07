using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacle : MonoBehaviour
{
    private Rotation _rotation;

    [Header("References")]
    [SerializeField] private Material _touchedMat;

    // M�thodes priv�es:
    private void Start()
    {
        _rotation = GetComponent<Rotation>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            _rotation.SetCanRotate(false);
            GetComponentInChildren<MeshRenderer>().material = _touchedMat;
        }
    }
}
