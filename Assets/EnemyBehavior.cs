using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    // 1
    
    public Transform player;
    // 1
    public Transform patrolRoute;
    // 2
    public List<Transform> locations;
    private int locationIndex = 0;
// 3
    private NavMeshAgent agent;
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        // 5
        //1MoveToNextPatrolLocation();
        player = GameObject.Find("Player").transform;
        agent.speed = 20;
        agent.acceleration = 30;
        agent.angularSpeed = 180;
        
    }
    // 4
    void InitializePatrolRoute()
    {
    // 5
        foreach(Transform child in patrolRoute)
        {
        // 6
        locations.Add(child);
        }
    }
    void Update()
    {
    // 1
    // if(agent.remainingDistance < 0.2f && !agent.pathPending)
    // {
    // // 2
    //    MoveToNextPatrolLocation();
        agent.destination = player.position;
    // }
    }
    void MoveToNextPatrolLocation()
    {
        // 3
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;
        
        // 4
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //ARDUINO STUFF
            } 
        // ... No changes needed ...
        }
    void OnTriggerExit(Collider other)
        {
        // ... No changes needed ...
        }
}