using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateActivation : MonoBehaviour
{
    // Attributs: 
    private List<GameObject> _colliderList = new List<GameObject>();

    [Header("References")]
    [SerializeField] private GameObject _objectActivated;
    [SerializeField] private GameObject _lightOn;
    [SerializeField] private GameObject _lightOff;
    [SerializeField] private Material _lightOnMat;
    [SerializeField] private Material _lightOffMat;
    [SerializeField] private Material _lightMat;

    private void OnTriggerEnter(Collider other) 
    {
        if (!_colliderList.Contains(other.gameObject) && (other.gameObject.tag == "Player" || other.gameObject.tag == "Copy"))
        {
            _colliderList.Add(other.gameObject);
            _lightOn.GetComponent<MeshRenderer>().material = _lightOnMat;
            _lightOff.GetComponent<MeshRenderer>().material = _lightMat;
            _objectActivated.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (_colliderList.Contains(other.gameObject) && (other.gameObject.tag == "Player" || other.gameObject.tag == "Copy"))
        {
            _colliderList.Remove(other.gameObject);

            if (_colliderList.Count.Equals(0)) 
            {
                _lightOn.GetComponent<MeshRenderer>().material = _lightMat;
                _lightOff.GetComponent<MeshRenderer>().material = _lightOffMat;
                _objectActivated.SetActive(true);
            }
        }
    }
}
