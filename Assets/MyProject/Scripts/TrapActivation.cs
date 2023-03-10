using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapActivation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _traps;
    [SerializeField] private GameObject[] _blockades;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            foreach (GameObject trap in _traps)
                trap.SetActive(true);

            foreach (GameObject blockade in _blockades)
                blockade.SetActive(true);
        }
    }
}
