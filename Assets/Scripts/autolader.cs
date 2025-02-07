using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autolader : MonoBehaviour
{
    public float flightSpeed = 2f;
    public float waypointReachedDistance = 0.1f;
    public List<Transform> waypoints;


    Rigidbody2D rb;

    Transform nextWaypoint;
    int waypointNum = 0;
    // Start is called before the first frame update
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        nextWaypoint = waypoints[waypointNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Flight();
    }
    private void Flight()
    {
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;

        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;

        UpdateDirection();

        if (distance <= waypointReachedDistance)
        {
            waypointNum++;

            if (waypointNum >= waypoints.Count)
            {
                waypointNum = 0;
            }

            nextWaypoint = waypoints[waypointNum];
        }
    }

    private void UpdateDirection()
    {
        Vector3 locScale = transform.localScale;
        if (transform.localScale.x > 0)
        {
            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
        else
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * locScale.x, locScale.y, locScale.z);
            }
        }
    }
}
