using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PhysicsObject))]

public abstract class Agent : MonoBehaviour
{

    //Abstract class that can't put it on any game objects

    [SerializeField]
    private PhysicsObject physicsObject;


    [SerializeField]
    float maxSpeed = 2f;

    [SerializeField]
    float maxForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        physicsObject = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // make sure targetPosition parameter is already in world space
    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = targetPosition - transform.position;

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        Vector3 seekForce = desiredVelocity - physicsObject.Velocity;

        return seekForce;
    }

}
