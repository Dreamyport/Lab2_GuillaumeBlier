using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPatrolPoint : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private GuardPatrol _guardPatrol;
    [SerializeField] private Transform _nextPoint;



    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "GuardBody") 
        {
            _guardPatrol.SetNextPoint();
        }
    }
}
