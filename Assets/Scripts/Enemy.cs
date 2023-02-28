using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

   

   

    private NavMeshAgent enemy;

    public Transform PlayerTarget;
    

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
           if (PlayerTarget != null)
    {
        enemy.SetDestination(PlayerTarget.position);
    }
       

    }

    

   
}
