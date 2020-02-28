using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void walk()
    {
        Quaternion rotation = Quaternion.LookRotation(wayPoint[currentWayPoint].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        Vector2 wayPointDirection = wayPoint[currentWayPoint].position - transform.position;
        float speedElement = Vector2.Dot(wayPointDirection.normalized, transform.forward);
        float speed = acceleration * speedElement;
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
    void onTriggerEnter(Collider collider)
    {
        if (collider.tag == "WayPoint")
        {
            currentWayPoint++;
        }
    }
}
