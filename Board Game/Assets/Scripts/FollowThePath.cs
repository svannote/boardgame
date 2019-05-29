using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    //array to hold waypoints
    public Transform[] waypoints;

    //var for speed, can change in unity
    [SerializeField] private float moveSpeed = 1f;

    //var for waypoint player is at currently
    [HideInInspector] public int waypointIndex = 0;

    //bool for if player can go
    public bool moveAllowed = false;
    
    // Start is called before the first frame update
    //set player at first waypoint
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    //if moveAllowed (from GameControl method), run function Move
    void Update()
    {
        if (moveAllowed)
        {
            Move();
        }
    }

    //move player across board until reach last spot (if run continuously would just move player across whole board
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}
