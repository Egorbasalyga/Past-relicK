using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RUN : MonoBehaviour
{
    public List<WaypointData> waypoints;
    public float moveSpeed = 3f;
    public float stoppingDistance = 0.5f;
    public float rotationSpeed = 5f;
    
    [Header("Rotation Settings")]
    public Vector3 rotationOffset = Vector3.zero;
    public bool useWaypointRotation = false;
    
    private bool isActive = false;
    private int currentWaypointIndex = 0;
    private bool isWaiting = false;
    private bool isFinalPointReached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StartWalk()
    {
        if (waypoints == null || waypoints.Count == 0)
        {
            Debug.LogError("No waypoints assigned!");
            return;
        }

        currentWaypointIndex = 0;
        isFinalPointReached = false;
        isActive = true;
        isWaiting = false;
        
        transform.position = waypoints[0].waypoint.position;
        ApplyWaypointRotation(waypoints[0].waypoint);
    }

    void Update()
    {
        if (!isActive || isFinalPointReached) return;
        
        if (!isWaiting)
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex].waypoint;
        Vector3 direction = targetWaypoint.position - transform.position;
        
        
        if (direction.magnitude > stoppingDistance)
        {
            RotateTowardsTarget(targetWaypoint, direction);
        }

        
        float distance = direction.magnitude;
        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetWaypoint.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            if (currentWaypointIndex == waypoints.Count - 1)
            {
                isFinalPointReached = true;
                return;
            }
            
            StartCoroutine(WaitAtWaypoint());
        }
    }

    void RotateTowardsTarget(Transform target, Vector3 direction)
    {
        Quaternion targetRotation;
        
        if (useWaypointRotation)
        {
       
            targetRotation = target.rotation * Quaternion.Euler(rotationOffset);
        }
        else
        {
            
            targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(rotationOffset);
        }

        transform.rotation = Quaternion.Slerp(
            transform.rotation, 
            targetRotation, 
            rotationSpeed * Time.deltaTime
        );
    }
    
    void ApplyWaypointRotation(Transform waypoint)
    {
        if (useWaypointRotation)
        {
            transform.rotation = waypoint.rotation * Quaternion.Euler(rotationOffset);
        }
    }

    IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waypoints[currentWaypointIndex].waitTime);
        
        currentWaypointIndex++;
        isWaiting = false;
        
       
        if (currentWaypointIndex < waypoints.Count)
        {
            ApplyWaypointRotation(waypoints[currentWaypointIndex].waypoint);
        }
    }
}

[System.Serializable]
public class WaypointData
{
    public Transform waypoint;
    public float waitTime = 2f;
}