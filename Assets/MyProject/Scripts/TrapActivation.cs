using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _trap;
    [SerializeField] private GameObject _blockade;
    [SerializeField] private GameObject _teleportObject;
    [SerializeField] private Transform _teleportLocation;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap") 
        {
            _trap.GetComponent<MeshRenderer>().material.color = Color.red;
            _teleportObject.transform.position = _teleportLocation.position; 
        }

        if (other.gameObject.tag == "Player") 
        {
            _trap.SetActive(true);
            _blockade.SetActive(true);
        }
    }
}
